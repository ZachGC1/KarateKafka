using BombSquad.Models;
using NBomber.Configuration;
using NBomber.Contracts;
using NBomber.CSharp;
using Newtonsoft.Json;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7009/Producer?message="),
    Timeout = TimeSpan.FromMilliseconds(3000),

};

Data userMove = JsonConvert.DeserializeObject<Data>(System.IO.File.ReadAllText(@"C:\Repos\KarateKafka\SharedData\data.json"));

var step = Step.Create("bomb_publisher", async context =>
{
    Random random = new Random();
    var msg = JsonConvert.SerializeObject(new UserMove(userMove.Users[random.Next(userMove.Users.Count)], userMove.Moves[random.Next(userMove.Users.Count)]));
    try
    {
        var response = await httpClient.GetAsync(msg);

        return response.IsSuccessStatusCode
            ? Response.Ok()
            : Response.Fail();

    }
    catch (Exception ex)
    {
        return Response.Fail();
    }
});

var scenario = ScenarioBuilder.CreateScenario("bomb_publisher_scenario", step)
   .WithWarmUpDuration(TimeSpan.FromSeconds(60))
   .WithLoadSimulations(
       Simulation.InjectPerSec(rate: 1000, during: TimeSpan.FromMinutes(2))
);

NBomberRunner
  .RegisterScenarios(scenario)
  .WithReportFileName("bomb_publisher_report_centrifugo")
  .WithReportFolder("bomb_publisher_reports")
  .WithReportFormats(ReportFormat.Txt, ReportFormat.Csv, ReportFormat.Html, ReportFormat.Md)
  .Run();
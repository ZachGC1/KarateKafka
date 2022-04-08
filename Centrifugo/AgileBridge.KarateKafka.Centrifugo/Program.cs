using BombSquad.Models;
using NBomber.Contracts;
using NBomber.CSharp;
using Newtonsoft.Json;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:8000/"),
    Timeout = TimeSpan.FromMilliseconds(3000),

};

Data userMove = JsonConvert.DeserializeObject<Data>(System.IO.File.ReadAllText(@"C:\Repos\KarateKafka\SharedData\data.json"));

var step = Step.Create("bomb_publisher", async context =>
{
    Random random = new Random();
    var msg = JsonConvert.SerializeObject(new UserMove(userMove.Users[random.Next(userMove.Users.Count)], userMove.Moves[random.Next(userMove.Users.Count)]));
    try
    {
        var body = new StringContent("{\"method\":\"publish\",\"params\":{\"channel\":\"channel\",\"data\":{\"value\":\"" + msg + "\"}}}");
        var response = await httpClient.PostAsync("api", body);

        return response.IsSuccessStatusCode
            ? Response.Ok()
            : Response.Fail();

    }
    catch (Exception ex)
    {
        return Response.Fail();
    }
});

var scenario = ScenarioBuilder.CreateScenario("bomb_users_scenario", step)
   .WithWarmUpDuration(TimeSpan.FromSeconds(60))
   .WithLoadSimulations(
       Simulation.InjectPerSec(rate: 1000, during: TimeSpan.FromMinutes(2))
);
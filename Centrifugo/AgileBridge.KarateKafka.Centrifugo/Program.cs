using BombSquad.Models;
using NBomber.Contracts;
using NBomber.CSharp;
using Newtonsoft.Json;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:9092/"),
    Timeout = TimeSpan.FromMilliseconds(10000)
};

UserMove userMove = JsonConvert.DeserializeObject<UserMove>(System.IO.File.ReadAllText(@"C:\Repos\KarateKafka\SharedData\data.json"));

var step = Step.Create("bomb_publisher", async context =>
{
    try
    {

        var response = await httpClient.PostAsync("api", );

        return response.IsSuccessStatusCode
            ? Response.Ok()
            : Response.Fail();

    }
    catch (Exception ex)
    {
        return Response.Fail();
    }
});
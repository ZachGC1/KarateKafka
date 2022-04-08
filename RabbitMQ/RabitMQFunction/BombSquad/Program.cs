using NBomber.Contracts;
using NBomber.CSharp;

using var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:9092/"),
    Timeout = TimeSpan.FromMilliseconds(10000)
};

var step = Step.Create("bomb_publisher", async context =>
{
    try
    {
        System.IO.File.ReadAllLines();

        var response = await httpClient.PostAsync("api/publish", );

        return response.IsSuccessStatusCode
            ? Response.Ok()
            : Response.Fail();

    }
    catch (Exception ex)
    {
        return Response.Fail();
    }
});
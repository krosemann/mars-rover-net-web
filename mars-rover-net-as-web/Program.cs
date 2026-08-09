using mars_rover_net_as_web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet(
        "/mars-rover",
        () => new MarsRover(1, 1)
    )
    .WithName("MarsRover");

app.Run();

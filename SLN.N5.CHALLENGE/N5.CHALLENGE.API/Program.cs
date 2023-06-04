using N5.CHALLENGE.API;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

builder
    .Build()
    .UseServices()
    .Run();

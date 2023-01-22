using CVManagementSystem.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDIContainer();

var app = builder.Build();


app.ConfigureFiles();

app.ConfigureSwagger();
app.ConfigurePipeLine();
app.Run();
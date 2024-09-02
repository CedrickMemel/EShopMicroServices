var builder = WebApplication.CreateBuilder(args);

//Add services ti the container
var app = builder.Build();

//Configure the HTTP request pipeline

app.Run();

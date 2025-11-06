using DZ1.Database;
using DZ1.Endpoints;
using DZ1.Interfaces;
using DZ1.Services;
using DZ1.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<Db>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserAuth, UserAuth>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
        options.RoutePrefix = "";
    });
}

app.MapUserEndpoints();
app.MapGet("/get_all_users", (Db db) => Results.Ok((object?)db.Users));

app.Run();

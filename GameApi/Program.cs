using Microsoft.EntityFrameworkCore;
using Level.Models;
using Project.Models;
using User.Models;
using GameApi.Services;
using MongoDB.Driver;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllers();

string connectionUri = "mongodb+srv://<user>:<pass>@gamedb.9gyot.mongodb.net/?retryWrites=true&w=majority&appName=GameDb";

builder.Services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(connectionUri));


builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IProjectService, ProjectServices>();
builder.Services.AddScoped<ILevelService, LevelService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

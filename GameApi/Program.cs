using Microsoft.EntityFrameworkCore;
using Level.Models;
using Project.Models;
using User.Models;
using GameApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("UserList"));
builder.Services.AddDbContext<ProjectContext>(opt =>
    opt.UseInMemoryDatabase("ProjectList"));
builder.Services.AddDbContext<LevelContext>(opt =>
    opt.UseInMemoryDatabase("LevelList"));

builder.Services.AddScoped<IProjectService, ProjectServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ILevelService, LevelService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
// {
//     var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
//     return new MongoClient(settings.ConnectionString);
// });

// builder.Services.AddScoped<IMongoDatabase>(sp =>
// {
//     var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
//     var client = sp.GetRequiredService<IMongoClient>();
//     return client.GetDatabase(settings.DatabaseName);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Level.Models;
using Project.Models;
using User.Models;
using GameApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

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

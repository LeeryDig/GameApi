using Level.Models;
using MongoDB.Driver;
using Project.Models;
using User.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase("GameDb");
    }

    public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("Users");
    public IMongoCollection<ProjectModel> Projects => _database.GetCollection<ProjectModel>("Projects");
    public IMongoCollection<LevelModel> Levels => _database.GetCollection<LevelModel>("Levels");
}

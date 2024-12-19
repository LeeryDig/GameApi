using MongoDB.Driver;
using User.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase("GameDb");
    }

    public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("Users");
}

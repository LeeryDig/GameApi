using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace User.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int Level { get; set; }
    public int Points { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class UserDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
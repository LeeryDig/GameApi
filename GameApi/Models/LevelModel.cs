using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Level.Models;

public class LevelModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public required string Name { get; set; }
    public required int LevelRequired { get; set; }
    public required string Image { get; set; }
}

public class LevelDto
{
    public required string Name { get; set; }
    public required int LevelRequired { get; set; }
    public required string Image { get; set; }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project.Models;

public class ProjectModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Difficulty { get; set; }
    public required float TimeRequired { get; set; }
    public bool IsComplete { get; set; }
}

public class ProjectDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Difficulty { get; set; }
    public required float TimeRequired { get; set; }
}
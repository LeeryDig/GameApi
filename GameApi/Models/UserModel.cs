using Level.Models;

namespace User.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public required string Name { get; set; }
    public int Level { get; set; }
    public long LevelId { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class UserDto
{
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
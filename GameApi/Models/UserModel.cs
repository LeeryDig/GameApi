using Level.Models;

namespace User.Models;

public class UserModel
{
    public long Id { get; set; }
    public int Level { get; set; }
    public long LevelId { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class UserDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
namespace Level.Models;

public class LevelModel
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required int Level { get; set; }
    public required string Image { get; set; }
}
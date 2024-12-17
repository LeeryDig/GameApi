namespace Project.Models;

public class ProjectModel
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required int Difficulty { get; set; }
    public required float TimeRequired { get; set; }
    public bool IsComplete { get; set; }
}

public class ProjectDto
{
    public required string Name { get; set; }
    public required int Difficulty { get; set; }
    public required float TimeRequired { get; set; }
}
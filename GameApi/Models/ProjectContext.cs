using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Models;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectModel> ProjectModels { get; set; } = null!;
}
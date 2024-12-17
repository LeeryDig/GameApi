using Microsoft.EntityFrameworkCore;
using Level.Models;

namespace Level.Models;

public class LevelContext : DbContext
{
    public LevelContext(DbContextOptions<LevelContext> options)
        : base(options)
    {
    }

    public DbSet<LevelModel> LevelModels { get; set; } = null!;
}
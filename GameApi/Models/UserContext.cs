using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> UserModels { get; set; } = null!;
}
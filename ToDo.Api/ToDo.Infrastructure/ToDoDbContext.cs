using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Services;
using ToDo.Infrastructure.EntityTypeConfigurations;

namespace ToDo.Infrastructure;

public class ToDoDbContext : DbContext
{
    private readonly IUserAccessor _userAccessor;

    public ToDoDbContext(DbContextOptions options, IUserAccessor userAccessor) : base(options)
    {
        _userAccessor = userAccessor;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

    }
}

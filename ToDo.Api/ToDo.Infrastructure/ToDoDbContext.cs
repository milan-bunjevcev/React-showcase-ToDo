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

    public DbSet<ToDoTask> ToDoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ToDoTaskEntityTypeConfiguration());

        ConfigureGlobalQueryFilter<ToDoTask>(modelBuilder);
    }

    private void ConfigureGlobalQueryFilter<T>(ModelBuilder builder)
        where T : class, IUserBelongingEntity
    {
        builder.Entity<T>().Property(p => p.UserId).IsRequired();
        builder.Entity<T>().HasIndex(p => p.UserId);
        builder.Entity<T>().HasQueryFilter(e => e.UserId == _userAccessor.CurrentUserId);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EntityTypeConfigurations;

public class ToDoTaskEntityTypeConfiguration : IEntityTypeConfiguration<ToDoTask>
{
    public void Configure(EntityTypeBuilder<ToDoTask> builder)
    {
        builder
            .Property(task => task.Name)
            .IsRequired()
            .HasMaxLength(ToDoTask.MaxNameLength);

        builder
            .Property(task => task.IsCompleted)
            .IsRequired();

        builder
            .Property(task => task.UserId)
            .IsRequired();
    }
}

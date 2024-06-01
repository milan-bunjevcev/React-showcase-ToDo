using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.Services;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Infrastructure;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IToDoTaskRepository, ToDoTaskRepository>()
            .AddScoped<IToDoTaskService, ToDoTaskService>()
            .AddScoped<IUserAccessor, UserAccessor>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>();

        serviceCollection
            .AddDbContext<ToDoDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("ToDoDbContext"));
            }, ServiceLifetime.Scoped);

        return serviceCollection;
    }
}
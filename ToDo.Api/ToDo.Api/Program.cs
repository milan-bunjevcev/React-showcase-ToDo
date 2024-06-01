using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Extensions;
using ToDo.Api.Middlewares;
using ToDo.Application.Extensions;
using ToDo.Infrastructure;

const string corsPolicy = "CORS Policy";

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerServices()
    .RegisterServices(builder.Configuration)
    .AddHttpContextAccessor()
    .AddJwtAuthentication(builder.Configuration)
    .AddCors(options =>
    {
        options.AddPolicy(name: corsPolicy, configurePolicy =>
        {
            configurePolicy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });;

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(null, allowIntegerValues: false));
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    EnsureDbIsCreated(app);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();

void EnsureDbIsCreated(IApplicationBuilder app)
{
    using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var context = serviceScope.ServiceProvider.GetService<ToDoDbContext>();
    context?.Database.Migrate();
}

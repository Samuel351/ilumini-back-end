using Domain.Entities;
using Infraestructure.Data.EntitiesConfigurations;
using Infrastructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Form> Forms { get; set; }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Option> Options { get; set; }

    public DbSet<FormInstance> FormInstances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FormEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OptionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FormInstanceEntityConfiguration());
    }
}

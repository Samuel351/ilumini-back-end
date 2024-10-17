using Domain.Entities;
using Infrastructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Form> Forms { get; set; }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Option> Options { get; set; }

    public DbSet<FormInstance> FormInstances { get; set; }

    public DbSet<FormInstanceResponse> FormInstancesResponse { get; set; }

    public DbSet<Recipient> Recipients { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        

        modelBuilder.ApplyConfiguration(new FormEntityConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OptionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FormInstanceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FormInstanceResponseEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RecipientEntityConfiguration());    
    }
}

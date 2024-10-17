using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.EntitiesConfigurations;

internal class EntityConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable($"{typeof(T).Name.ToLower()}");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasQueryFilter(x => !x.Deleted);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.LastUpdatedAt);
        builder.Property(x => x.Status).HasDefaultValue(true);
    }
}

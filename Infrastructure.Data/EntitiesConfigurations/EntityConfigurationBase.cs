using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.EntitiesConfigurations;

internal class EntityConfigurationBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => !x.Deleted);
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getDate()");
        builder.Property(x => x.LastUpdatedAt).ValueGeneratedOnUpdate();
        builder.Property(x => x.Status).HasDefaultValue(true);
    }
}

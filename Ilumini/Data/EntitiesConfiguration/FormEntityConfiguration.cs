using Ilumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilumini.Data.EntitiesConfiguration
{
    public class FormEntityConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId);

            builder.HasMany(x => x.FormInstances)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId);
        }
    }
}

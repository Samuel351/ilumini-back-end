using Ilumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilumini.Data.EntitiesConfiguration
{
    public class FormInstanceEntityConfiguration : IEntityTypeConfiguration<FormInstance>
    {
        public void Configure(EntityTypeBuilder<FormInstance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Form)
                .WithMany(x => x.FormInstances)
                .HasForeignKey(x => x.Id);

            builder.HasMany(x => x.Responses)
                .WithOne(x => x.FormInstance)
                .HasForeignKey(x => x.FormInstanceId);
        }
    }
}

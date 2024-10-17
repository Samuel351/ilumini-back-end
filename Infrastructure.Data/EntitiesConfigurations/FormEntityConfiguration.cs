using Domain.Entities;
using Infraestructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations
{
    internal class FormEntityConfiguration : EntityConfigurationBase<Form>
    {

        public override void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId);

            builder.HasMany(x => x.Instances)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            base.Configure(builder);
        }
    }
}

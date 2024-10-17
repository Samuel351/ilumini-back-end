using Domain.Entities;
using Infraestructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EntitiesConfigurations
{
    internal class FormInstanceResponseEntityConfiguration : EntityConfigurationBase<FormInstanceResponse>
    {
        public override void Configure(EntityTypeBuilder<FormInstanceResponse> builder)
        {

            builder.HasOne(x => x.FormInstance)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.FormInstanceId);

            builder.Property(x => x.FormInstanceId)
                .IsRequired();

            builder.HasOne(x => x.Option)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.OptionId);

            builder.Property(x => x.OptionId).IsRequired();

            base.Configure(builder);
        }
    }
}

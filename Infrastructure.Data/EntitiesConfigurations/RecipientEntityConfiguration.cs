using Domain.Entities;
using Infraestructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntitiesConfigurations
{
    internal class RecipientEntityConfiguration : EntityConfigurationBase<Recipient>
    {
        public override void Configure(EntityTypeBuilder<Recipient> builder)
        {

            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x => x.Responses)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId);

            builder.HasMany(x => x.FormInstances)
                .WithMany(x => x.Recipients);

            base.Configure(builder);
        }
    }
}

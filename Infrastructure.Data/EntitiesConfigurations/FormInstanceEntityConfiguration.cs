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
    internal class FormInstanceEntityConfiguration : EntityConfigurationBase<FormInstance>
    {

        public override void Configure(EntityTypeBuilder<FormInstance> builder)
        {
            builder.HasOne(x => x.Form)
                .WithMany(x => x.Instances)
                .HasForeignKey(x => x.FormId);

            builder.Property(x => x.LaunchName).IsRequired();

            base.Configure(builder);
        }

    }
}

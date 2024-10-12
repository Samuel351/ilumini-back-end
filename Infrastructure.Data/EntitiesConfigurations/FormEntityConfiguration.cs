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
    internal class FormEntityConfiguration : EntityConfigurationBase<Form>
    {

        public override void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            base.Configure(builder);
        }
    }
}

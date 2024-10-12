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
    internal class QuestionEntityConfiguration : EntityConfigurationBase<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasMany(x => x.Options)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

            

            base.Configure(builder);
        }
    }
}

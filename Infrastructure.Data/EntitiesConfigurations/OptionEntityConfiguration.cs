using Domain.Entities;
using Infraestructure.Data.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations
{
    internal class OptionEntityConfiguration : EntityConfigurationBase<Option>
    {
        public override void Configure(EntityTypeBuilder<Option> builder)
        {

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.QuestionId);

            base.Configure(builder);
        }
    }
}

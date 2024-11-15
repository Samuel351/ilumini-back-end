using Ilumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilumini.Data.EntitiesConfiguration
{
    public class OptionEntityConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Statement).IsRequired();

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.QuestionId);  
        }
    }
}

using Ilumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilumini.Data.EntitiesConfiguration
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Statement);

            builder.HasOne(x => x.Form)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.FormId);

            builder.HasMany(x => x.Options)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}

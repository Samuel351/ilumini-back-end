using Ilumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ilumini.Data.EntitiesConfiguration
{
    public class ResponseEntityConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.HasKey(x => new { x.RecipientId, x.QuestionId, x.FormInstanceId, x.OptionId });

            builder.HasOne(x => x.FormInstance)
                .WithMany(x => x.Responses)
                .HasForeignKey(x => x.FormInstanceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Option)
                .WithMany()
                .HasForeignKey(x => x.OptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Recipient).IsRequired();

        }
    }
}

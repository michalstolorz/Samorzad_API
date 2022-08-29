using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Invoice_API.Data.EntityConfiguration
{
    public class ApplicationCommentConfiguration : IEntityTypeConfiguration<ApplicationComment>
    {
        public void Configure(EntityTypeBuilder<ApplicationComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ApplicationId)
                .IsRequired();

            builder.Property(x => x.AddDateTime)
                .IsRequired();

            builder.Property(x => x.CommentText)
                .IsRequired();

            builder.HasOne(x => x.Application)
                .WithMany(x => x.ApplicationComments)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.ApplicationComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

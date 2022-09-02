using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Invoice_API.Data.EntityConfiguration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Body)
                .IsRequired();

            builder.Property(x => x.CreateDateTime)
                .HasColumnType("datetime2(0)")
                .IsRequired();

            builder.Property(x => x.EndVoteDateTime)
                .HasColumnType("datetime2(0)")
                .IsRequired();

            builder.Property(x => x.ApplicationStatus)
                .IsRequired();

            builder.Property(x => x.Question)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ApplicationUserVotes)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ApplicationComments)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

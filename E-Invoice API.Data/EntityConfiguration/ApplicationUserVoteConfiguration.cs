using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Invoice_API.Data.EntityConfiguration
{
    public class ApplicationUserVoteConfiguration : IEntityTypeConfiguration<ApplicationUserVote>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserVote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ApplicationId)
                .IsRequired();

            builder.Property(x => x.Vote)
                .IsRequired();

            builder.HasOne(x => x.Application)
                .WithMany(x => x.ApplicationUserVotes)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

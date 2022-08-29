using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Data.EntityConfiguration
{
    public class ForumCommentConfiguration : IEntityTypeConfiguration<ForumComment>
    {
        public void Configure(EntityTypeBuilder<ForumComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ThreadId)
                .IsRequired();

            builder.Property(x => x.CommentText)
                .IsRequired();

            builder.Property(x => x.CreateDateTime)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.ForumComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ForumThread)
                .WithMany(x => x.ForumComments)
                .HasForeignKey(x => x.ThreadId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

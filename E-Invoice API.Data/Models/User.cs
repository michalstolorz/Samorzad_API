using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace E_Invoice_API.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<ApplicationComment> ApplicationComments { get; set; }
        public virtual ICollection<MailHistory> UserMailHistory { get; set; }
        public virtual ICollection<ApplicationUserVote> ApplicationUserVotes { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }
}
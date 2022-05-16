using System;
using System.Collections.Generic;

namespace E_Invoice_API.Data.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime EndVoteDateTime { get; set; }
        public byte ApplicationStatus { get; set; }

        public User User { get; set; }
        public virtual ICollection<ApplicationComment> ApplicationComments { get; set; }
        public virtual ICollection<ApplicationUserVote> ApplicationUserVotes { get; set; }
    }
}

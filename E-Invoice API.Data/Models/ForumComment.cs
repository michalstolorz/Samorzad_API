using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Data.Models
{
    public class ForumComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ThreadId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDateTime { get; set; }

        public User User { get; set; }
        public ForumThread ForumThread { get; set; }
    }
}

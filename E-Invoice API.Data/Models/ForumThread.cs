using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Data.Models
{
    public class ForumThread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }
}

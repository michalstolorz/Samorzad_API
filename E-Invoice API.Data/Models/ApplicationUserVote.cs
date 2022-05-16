
namespace E_Invoice_API.Data.Models
{
    public class ApplicationUserVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public bool Vote { get; set; }
        public User User { get; set; }
        public Application Application { get; set; }
    }
}


namespace E_Invoice_API.Data.Models
{
    public class ApplicationComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }

        public User User { get; set; }
        public Application Application { get; set; }
    }
}

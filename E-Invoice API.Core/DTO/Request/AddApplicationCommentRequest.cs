using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.DTO.Request
{
    public class AddApplicationCommentRequest
    {
        public int ApplicationId { get; set; }
        public string Title { get; set; }
        public string CommentText { get; set; }
    }
}

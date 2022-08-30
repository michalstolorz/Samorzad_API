using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Interfaces.Services
{
    public interface IForumCommentService
    {
        Task<List<ForumComment>> GetCommentsForThread(int? threadId, CancellationToken cancellationToken);
        Task CreateForumComment(CreateForumCommentRequest request, CancellationToken cancellationToken);
        Task DeleteForumComment(int forumCommentId, CancellationToken cancellationToken);
        Task UpdateForumComment(UpdateForumCommentRequest request, CancellationToken cancellationToken);
    }
}

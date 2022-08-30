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
    public interface IForumThreadService
    {
        Task CreateThread(CreateForumThreadRequest request, CancellationToken cancellationToken);
        Task<ForumThread> GetThread(int forumThreadId, CancellationToken cancellationToken);
        Task<List<ForumThread>> GetThreads(int? forumThreadId, CancellationToken cancellationToken);
        Task DeleteThread(int forumThreadId, CancellationToken cancellationToken);
        Task UpdateThread(UpdateForumThreadRequest request, CancellationToken cancellationToken);
    }
}

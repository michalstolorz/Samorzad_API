using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.Exceptions;
using E_Invoice_API.Core.Helper;
using E_Invoice_API.Core.Interfaces.Repositories;
using E_Invoice_API.Core.Interfaces.Services;
using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Services
{
    public class ForumThreadService : IForumThreadService
    {
        private readonly IForumThreadRepository _forumThreadRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ForumThreadService(IForumThreadRepository forumThreadRepository,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _forumThreadRepository = forumThreadRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task CreateThread(CreateForumThreadRequest request, CancellationToken cancellationToken)
        {
            var threadToCreate = new ForumThread()
            {
                Body = request.Body,
                Title = request.Title,
                UserId = (int)_userContextProvider.UserId,
                CreateDateTime = _dateTimeProvider.GetDateTimeNow()
            };

            await _forumThreadRepository.AddAsync(threadToCreate, cancellationToken);
        }

        public async Task<ForumThread> GetThread(int forumThreadId, CancellationToken cancellationToken)
        {
            var result = await _forumThreadRepository.GetByIdAsync(forumThreadId, cancellationToken,
                include: x => x
                .Include(x => x.User)
                .Include(x => x.ForumComments));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ForumThreadWithGivenIdNotFound, $"Forum thread with provided id doesn't exist");
            }

            return result;
        }

        public async Task<List<ForumThread>> GetThreads(int? forumThreadId, CancellationToken cancellationToken)
        {
            Expression<Func<ForumThread, bool>> predicate = x =>
                   !forumThreadId.HasValue || x.Id.Equals(forumThreadId);

            var result = await _forumThreadRepository.GetAsync(predicate, cancellationToken,
                include: x => x
                .Include(x => x.User)
                .Include(x => x.ForumComments));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ForumThreadWithGivenIdNotFound, $"Forum thread with provided id doesn't exist");
            }

            return result.ToList();
        }

        public async Task DeleteThread(int forumThreadId, CancellationToken cancellationToken)
        {
            var forumThreadToDelete = await _forumThreadRepository.GetByIdAsync(forumThreadId, cancellationToken);

            await _forumThreadRepository.Delete(forumThreadToDelete, cancellationToken);
        }

        public async Task UpdateThread(UpdateForumThreadRequest request, CancellationToken cancellationToken)
        {
            var forumThread = await _forumThreadRepository.GetByIdAsync(request.ThreadId, cancellationToken);

            forumThread.Body = request.Body;
            forumThread.Title = request.Title;

            await _forumThreadRepository.UpdateAsync(forumThread, cancellationToken);
        }
    }
}

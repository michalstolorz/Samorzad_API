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
    public class ForumCommentService : IForumCommentService
    {
        private readonly IForumCommentRepository _forumCommentRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ForumCommentService(IForumCommentRepository forumCommentRepository,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _forumCommentRepository = forumCommentRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<List<ForumComment>> GetCommentsForThread(int? threadId, CancellationToken cancellationToken)
        {
            Expression<Func<ForumComment, bool>> predicate = x =>
                (!threadId.HasValue || x.ThreadId.Equals(threadId));

            var result = await _forumCommentRepository.GetAsync(predicate, cancellationToken,
                include: x => x
                .Include(x => x.User));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ForumCommentWithGivenIdNotFound, $"Forum comment with provided id doesn't exist");
            }

            return result.ToList();
        }

        public async Task CreateForumComment(CreateForumCommentRequest request, CancellationToken cancellationToken)
        {
            var commentToCreate = new ForumComment()
            {
                CommentText = request.CommentText,
                CreateDateTime = _dateTimeProvider.GetDateTimeNow(),
                ThreadId = request.ThreadId,
                UserId = (int)_userContextProvider.UserId
            };

            await _forumCommentRepository.AddAsync(commentToCreate, cancellationToken);
        }

        public async Task DeleteForumComment(int forumCommentId, CancellationToken cancellationToken)
        {
            var forumCommentToDelete = await _forumCommentRepository.GetByIdAsync(forumCommentId, cancellationToken);

            await _forumCommentRepository.Delete(forumCommentToDelete, cancellationToken);
        }

        public async Task UpdateForumComment(UpdateForumCommentRequest request, CancellationToken cancellationToken)
        {
            var forumComment = await _forumCommentRepository.GetByIdAsync(request.CommentId, cancellationToken);

            forumComment.CommentText = request.CommentText;

            await _forumCommentRepository.UpdateAsync(forumComment, cancellationToken);
        }
    }
}

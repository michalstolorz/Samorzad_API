using E_Invoice_API.Common.Enums;
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
using System.Threading;
using System.Threading.Tasks;


namespace E_Invoice_API.Core.Services
{
    public class ApplicationCommentService : IApplicationCommentService
    {
        private readonly IApplicationCommentRepository _applicationCommentRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationCommentService(IApplicationCommentRepository applicationCommentRepository,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _applicationCommentRepository = applicationCommentRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<List<ApplicationComment>> GetApplicationCommentsForApplication(int? applicationId, CancellationToken cancellationToken)
        {
            Expression<Func<ApplicationComment, bool>> predicate = x =>
                   !applicationId.HasValue || x.Id.Equals(applicationId);

            var result = await _applicationCommentRepository.GetAsync(predicate, cancellationToken,
                include: x => x
                .Include(x => x.User)
                .Include(x => x.Application));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ApplicationCommentWithGivenIdNotFound, $"ApplicationComment with provided id doesn't exist");
            }

            return result.ToList();
        }

        public async Task DeleteApplicationComment(int applicationId, CancellationToken cancellationToken)
        {
            var applicationCommentToDelete = await _applicationCommentRepository.GetByIdAsync(applicationId, cancellationToken);

            await _applicationCommentRepository.Delete(applicationCommentToDelete, cancellationToken);
        }

        public async Task CreateApplicationComment(AddApplicationCommentRequest request, CancellationToken cancellationToken)
        {
            var userId = _userContextProvider.UserId;

            var comment = new ApplicationComment()
            {
                UserId = (int)userId,
                ApplicationId = request.ApplicationId,
                AddDateTime = _dateTimeProvider.GetDateTimeNow(),
                CommentText = request.CommentText
            };

            await _applicationCommentRepository.AddAsync(comment, cancellationToken);
        }
    }
}

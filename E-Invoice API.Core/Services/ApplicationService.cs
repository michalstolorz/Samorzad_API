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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationService(IApplicationRepository applicationRepository, 
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _applicationRepository = applicationRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task CreateApplication(CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            var userId = _userContextProvider.UserId;

            var application = new Application()
            {
                UserId = (int)userId,
                Title = request.Title,
                Body = request.Body,
                CreateDateTime = _dateTimeProvider.GetDateTimeNow(),
                EndVoteDateTime = _dateTimeProvider.GetDateTimeNow().AddDays(3),
                ApplicationStatus = (byte)ApplicationsStatus.New
            };

            await _applicationRepository.AddAsync(application, cancellationToken);
        }

        public async Task<Application> GetApplication(int id, CancellationToken cancellationToken)
        {
            var result = await _applicationRepository.GetByIdAsync(id, cancellationToken, 
                include: x => x
                .Include(x => x.User)
                .Include(x => x.ApplicationComments)
                .Include(x => x.ApplicationUserVotes));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ApplicationWithGivenIdNotFound, $"Application with provided id doesn't exist");
            }

            return result;
        }

        public async Task<List<Application>> GetApplications(GetApplicationsRequest request, CancellationToken cancellationToken)
        {
            var predicate = CreatePredicate(request);

            var result = await _applicationRepository.GetAsync(predicate, cancellationToken,
                include: x => x
                .Include(x => x.User)
                .Include(x => x.ApplicationComments)
                .Include(x => x.ApplicationUserVotes));

            return result.ToList();
        }

        public async Task DeleteApplication(int applicationId, CancellationToken cancellationToken)
        {
            var applicationToDelete = await _applicationRepository.GetByIdAsync(applicationId, cancellationToken);

            await _applicationRepository.Delete(applicationToDelete, cancellationToken);
        }

        private Expression<Func<Application, bool>> CreatePredicate(GetApplicationsRequest request)
        {
            Expression<Func<Application, bool>> predicate = x =>
                (!request.Id.HasValue || x.Id.Equals(request.Id));

            return predicate;
        }
    }
}

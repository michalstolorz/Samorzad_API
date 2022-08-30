using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.DTO.Response;
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
    public class ApplicationUserVoteService : IApplicationUserVoteService
    {
        private readonly IApplicationUserVoteRepository _applicationUserVoteRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationUserVoteService(IApplicationUserVoteRepository applicationUserVoteRepository,
                                         IUserContextProvider userContextProvider,
                                         IDateTimeProvider dateTimeProvider)
        {
            _applicationUserVoteRepository = applicationUserVoteRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task VoteForApplication(VoteForApplicationRequest request, CancellationToken cancellationToken)
        {
            var vote = new ApplicationUserVote()
            {
                UserId = (int)_userContextProvider.UserId,
                ApplicationId = request.ApplicationId, 
                Vote = request.Vote
            };

            await _applicationUserVoteRepository.AddAsync(vote, cancellationToken);
        }

        public async Task<List<ApplicationUserVote>> GetVotesForApplication(int? applicationId, CancellationToken cancellationToken)
        {
            Expression<Func<ApplicationUserVote, bool>> predicate = x =>
                   !applicationId.HasValue || x.ApplicationId.Equals(applicationId);

            var result = await _applicationUserVoteRepository.GetAsync(predicate, cancellationToken,
                include: x => x
                .Include(x => x.User)
                .Include(x => x.Application));

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ApplicationUserVoteWithGivenIdNotFound, $"ApplicationUserVote with provided id doesn't exist");
            }

            return result.ToList();
        }

        public async Task<GetApplicationVoteSummaryResponse> GetApplicationVoteSummary(int? applicationId, CancellationToken cancellationToken)
        {
            var votesForApplication = await this.GetVotesForApplication(applicationId, cancellationToken);

            var response = new GetApplicationVoteSummaryResponse()
            {
                VotesFor = 0,
                VotesAgainst = 0,
                VotesCount = votesForApplication.Count()
            };

            foreach (var votes in votesForApplication)
            {
                if (votes.Vote == true)
                {
                    response.VotesFor++;
                }
                else
                {
                    response.VotesAgainst++;
                }
            }

            return response;
        }
    }
}

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
    public interface IApplicationUserVoteService
    {
        Task VoteForApplication(VoteForApplicationRequest request, CancellationToken cancellationToken);
        Task<List<ApplicationUserVote>> GetVotesForApplication(int? applicationId, CancellationToken cancellationToken);
    }
}

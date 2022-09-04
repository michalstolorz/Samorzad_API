using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.Helper;
using E_Invoice_API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace E_Invoice_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IApplicationUserVoteService _applicationUserVoteService;

        public VoteController(IApplicationUserVoteService applicationUserVoteService)
        {
            _applicationUserVoteService = applicationUserVoteService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("voteForApplication")]
        [Authorize]
        public async Task<IActionResult> VoteForApplication(VoteForApplicationRequest request, CancellationToken cancellationToken)
        {
            await _applicationUserVoteService.VoteForApplication(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getVotesForApplication/{applicationId}")]
        [Authorize]
        public async Task<IActionResult> GetVotesForApplication(int applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationUserVoteService.GetVotesForApplication(applicationId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getApplicationVoteSummary/{applicationId}")]
        [Authorize]
        public async Task<IActionResult> GetApplicationVoteSummary(int applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationUserVoteService.GetApplicationVoteSummary(applicationId, cancellationToken);

            return Ok(result);
        }
    }
}

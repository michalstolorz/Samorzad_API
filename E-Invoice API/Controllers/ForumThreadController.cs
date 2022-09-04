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
    public class ForumThreadController : ControllerBase
    {
        private readonly IForumThreadService _forumThreadService;

        public ForumThreadController(IForumThreadService forumThreadService)
        {
            _forumThreadService = forumThreadService;
        }

        /// <summary>
        /// CreateThread.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("createThread")]
        [Authorize]
        public async Task<IActionResult> CreateThread(CreateForumThreadRequest request, CancellationToken cancellationToken)
        {
            await _forumThreadService.CreateThread(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// GetThread.
        /// </summary>
        /// <param name="forumThreadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getThread/{forumThreadId}")]
        public async Task<IActionResult> GetThread(int forumThreadId, CancellationToken cancellationToken)
        {
            var result = await _forumThreadService.GetThread(forumThreadId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// GetThreads.
        /// </summary>
        /// <param name="forumThreadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getThreads")]
        public async Task<IActionResult> GetThreads(int? forumThreadId, CancellationToken cancellationToken)
        {
            var result = await _forumThreadService.GetThreads(forumThreadId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// DeleteThread.
        /// </summary>
        /// <param name="forumThreadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deleteThread")]
        [Authorize]
        public async Task<IActionResult> DeleteThread(int forumThreadId, CancellationToken cancellationToken)
        {
            await _forumThreadService.DeleteThread(forumThreadId, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// UpdateThread
        /// </summary>
        /// <param name="request">But this is request for update</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("updateThread")]
        [Authorize]
        public async Task<IActionResult> UpdateThread(UpdateForumThreadRequest request, CancellationToken cancellationToken)
        {
            await _forumThreadService.UpdateThread(request, cancellationToken);

            return Ok();
        }
    }
}

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
    public class ForumCommentController : ControllerBase
    {
        private readonly IForumCommentService _forumCommentService;

        public ForumCommentController(IForumCommentService forumCommentService)
        {
            _forumCommentService = forumCommentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getCommentsForThread/{threadId}")]
        public async Task<IActionResult> GetCommentsForThread(int threadId, CancellationToken cancellationToken)
        {
            var result = _forumCommentService.GetCommentsForThread(threadId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("createForumComment")]
        [Authorize]
        public async Task<IActionResult> CreateForumComment(CreateForumCommentRequest request, CancellationToken cancellationToken)
        {
            await _forumCommentService.CreateForumComment(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forumCommentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deleteForumComment")]
        public async Task<IActionResult> DeleteForumComment(int forumCommentId, CancellationToken cancellationToken)
        {
            await _forumCommentService.DeleteForumComment(forumCommentId, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("updateFourmComment")]
        public async Task<IActionResult> UpdateFourmComment(UpdateForumCommentRequest request, CancellationToken cancellationToken)
        {
            await _forumCommentService.UpdateForumComment(request, cancellationToken);

            return Ok();
        }
    }
}

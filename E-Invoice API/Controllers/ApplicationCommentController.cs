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
    public class ApplicationCommentController : ControllerBase
    {
        private readonly IApplicationCommentService _applicationCommentService;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationCommentController(IApplicationCommentService applicationCommentService,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _applicationCommentService = applicationCommentService;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("createApplicationComment")]
        [Authorize]
        public async Task<IActionResult> CreateApplicationComment(AddApplicationCommentRequest request, CancellationToken cancellationToken)
        {
            await _applicationCommentService.CreateApplicationComment(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCommentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deleteApplicationComment/{applicationId}")]
        [Authorize]
        public async Task<IActionResult> DeleteApplicationComment(int applicationCommentId, CancellationToken cancellationToken)
        {
            await _applicationCommentService.DeleteApplicationComment(applicationCommentId, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getApplicationCommentForApplication/{applicationId}")]
        public async Task<IActionResult> GetApplicationCommentsForApplication(int applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationCommentService.GetApplicationCommentsForApplication(applicationId, cancellationToken);

            return Ok(result);
        }
    }
}

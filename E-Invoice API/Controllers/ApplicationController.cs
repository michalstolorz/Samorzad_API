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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserContextProvider _userContextProvider;

        public ApplicationController(IApplicationService applicationService, 
            IDateTimeProvider dateTimeProvider, 
            IUserContextProvider userContextProvider)
        {
            _applicationService = applicationService;
            _dateTimeProvider = dateTimeProvider;
            _userContextProvider = userContextProvider;
        }

        /// <summary>
        /// CreateApplication
        /// </summary>
        /// <returns></returns>
        [HttpPost("createApplication")]
        [Authorize]
        public async Task<IActionResult> CreateApplication(CreateApplicationRequest request, CancellationToken cancellationToken)
        {
            await _applicationService.CreateApplication(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// GetApplication
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getApplication/{applicationId}")]
        //[Authorize]
        public async Task<IActionResult> GetApplication(int applicationId, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplication(applicationId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// GetApplication
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getApplications")]
        //[Authorize]
        public async Task<IActionResult> GetApplications([FromQuery] GetApplicationsRequest request, CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetApplications(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deleteApplication/{applicationId}")]
        public async Task<IActionResult> DeleteApplication(int applicationId, CancellationToken cancellationToken)
        {
            await _applicationService.DeleteApplication(applicationId, cancellationToken);

            return Ok();
        }
    }
}

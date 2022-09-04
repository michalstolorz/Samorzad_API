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
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _FAQService;

        public FAQController(IFAQService FAQService)
        {
            _FAQService = FAQService;
        }

        /// <summary>
        ///GetFAQs.
        /// </summary>
        /// <param name="FAQId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getFAQs")]
        [Authorize]
        public async Task<IActionResult> GetFAQs(int? FAQId, CancellationToken cancellationToken)
        {
            var result = await _FAQService.GetFAQs(FAQId, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// CreateFAQ.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("createFAQ")]
        [Authorize]
        public async Task<IActionResult> CreateFAQ(CreateFAQRequest request, CancellationToken cancellationToken)
        {
            await _FAQService.CreateFAQ(request, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// DeleteFAQ.
        /// </summary>
        /// <param name="FAQId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("deleteFAQ")]
        [Authorize]
        public async Task<IActionResult> DeleteFAQ(int FAQId, CancellationToken cancellationToken)
        {
            await _FAQService.DeleteFAQ(FAQId, cancellationToken);

            return Ok();
        }
    }
}

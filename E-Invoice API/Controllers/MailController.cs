using E_Invoice_API.Core.DTO.Request;
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
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// SendMailToAdminForRegistration.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("sendMailToAdminForRegistration")]
        public async Task<IActionResult> SendMailToAdminForRegistration(SendMailToAdminForRegistrationRequest request, CancellationToken cancellationToken)
        {
            var response = await _mailService.SendMailToAdminForRegistration(request, cancellationToken);

            return Ok(response);
        }
    }
}

using System;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            await _emailService.SendEmailAsync(
                emailRequest.Anrede,
                emailRequest.VorName,
                emailRequest.NachName,
                emailRequest.AbsenderEmail,
                emailRequest.Nachricht
            );

            return Ok("Die E-Mail wurde gesendet.");
        }
    }
}


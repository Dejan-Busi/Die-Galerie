using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(
            string anrede,
            string vorName,
            string nachName,
            string absenderEmail,
            string nachricht
            );
    }
}
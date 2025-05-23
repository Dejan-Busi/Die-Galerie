using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class LoginResponseDto
    {
        public string? Email { get; set; }

        public string? AccessToken { get; set; }

        public bool RememberMe { get; set; }
    }
}


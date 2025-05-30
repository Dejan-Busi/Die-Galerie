using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Authentication
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Bitte gebe deine E-Mail Adresse ein.")]
        [EmailAddress]
        [DefaultValue("")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bitte gebe dein Passwort ein.")]
        [DefaultValue("")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}


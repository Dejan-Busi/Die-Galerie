using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Authentication
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Bitte gebe deine E-Mail ein. ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bitte gebe ein Passwort ein.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
        public string ConfirmPassword { get; set; }
    }
}


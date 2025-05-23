using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue("")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bitte gebe dein Passwort ein.")]
        [DefaultValue("")]
        public string Password { get; set; }

        [Required]
        [DefaultValue("")]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
        public string ConfirmPassword { get; set; }
    }
}


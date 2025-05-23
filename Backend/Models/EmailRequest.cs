using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class EmailRequest
    {
        [DefaultValue("")]
        public string? Anrede { get; set; }

        [Required (ErrorMessage = "Bitte gebe deinen Vornamen ein.")]
        [DefaultValue("")]
        public string? VorName { get; set; }

        [Required (ErrorMessage = "Bitte gebe deinen Nachnamen ein.")]
        [DefaultValue("")]
        public string? NachName { get; set; }

        [Required (ErrorMessage = "Bitte gebe deine Kontakt-Email ein.")]
        [DefaultValue("")]
        public string? AbsenderEmail { get; set; }

        [Required (ErrorMessage = "Bitte gebe deine Nachricht ein.")]
        [DefaultValue("")]
        public string? Nachricht { get; set; }
    }
}


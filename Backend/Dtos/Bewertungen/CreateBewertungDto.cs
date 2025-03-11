using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Bewertungen
{
    public class CreateBewertungDto
    {
        [Required(ErrorMessage = "Bitte fülle alle Felder aus.")]
        [DefaultValue(0)]
        public int Note { get; set; }

        [Required(ErrorMessage = "Bitte fülle alle Felder aus.")]
        [DefaultValue("")]
        public string? Kommentar { get; set; }

        [Required(ErrorMessage = "Bitte fülle alle Felder aus.")]
        [DefaultValue("")]
        public string? GepostetVon { get; set; }

        public DateTime GepostetAm { get; set; } = DateTime.Now;
    }
}


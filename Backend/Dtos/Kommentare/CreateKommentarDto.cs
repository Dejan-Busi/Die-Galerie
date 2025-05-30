using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Kommentare
{
    public class CreateKommentarDto
    {
        [Required(ErrorMessage = "Bitte benote das Gemälde.")]
        [DefaultValue(0)]
        public int Note { get; set; }

        [Required(ErrorMessage = "Bitte gebe einen Kommentar ein.")]
        [DefaultValue("")]
        public string? Inhalt { get; set; }

        [DefaultValue("")]
        public string? GepostetVon { get; set; }

        public string GepostetAm { get; set; } = DateTime.Now.ToString("dd. MM. yyyy, HH:mm");
    }
}


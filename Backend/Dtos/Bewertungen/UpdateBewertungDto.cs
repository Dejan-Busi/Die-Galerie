using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Bewertungen
{
    public class UpdateBewertungDto
    {
        public int Note { get; set; }

        public string? Kommentar { get; set; }

        public string? GepostetVon { get; set; }

        public DateTime GepostetAm { get; set; } = DateTime.Now;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Kommentare
{
    public class UpdateKommentarDto
    {
        public int Note { get; set; }

        public string? Inhalt { get; set; }

        public string GepostetAm { get; set; } = DateTime.Now.ToString("dd. MM. yyyy, HH:mm");
    }
}
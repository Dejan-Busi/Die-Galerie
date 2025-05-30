using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Kommentar
    {
        public int Id { get; set; }

        public int Note { get; set; }

        public string? Inhalt { get; set; }

        public string? GepostetVon { get; set; }

        public string GepostetAm { get; set; } = DateTime.Now.ToString("dd. MM. yyyy, HH:mm");

        public int? GemaeldeId { get; set; }

        public Gemaelde? Gemaelde { get; set; }
        
    }
}


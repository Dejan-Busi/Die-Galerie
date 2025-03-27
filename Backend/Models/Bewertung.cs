using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Bewertung
    {
        public int Id { get; set; }

        public int Note { get; set; }

        public string? Kommentar { get; set; }

        public string? GepostetVon { get; set; }

        public string GepostetAm { get; set; } = DateTime.Now.ToString("dd. MM. yyyy, HH:mm");

        public int? GemaeldeId { get; set; }

        public Gemaelde? Gemaelde { get; set; }
        
    }
}
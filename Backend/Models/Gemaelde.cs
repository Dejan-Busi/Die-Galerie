using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Gemaelde
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Kommentar> Kommentare { get; set; } = new List<Kommentar>();
    }
}



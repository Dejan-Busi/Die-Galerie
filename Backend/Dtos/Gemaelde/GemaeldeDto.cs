using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Kommentare;
using Backend.Models;

namespace Backend.Dtos.Gemaelde
{
    public class GemaeldeDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<KommentarDto> Kommentare {get; set; }
    }
}


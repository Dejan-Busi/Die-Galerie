using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Gemaelde;
using Backend.Models;

namespace Backend.Mappers
{
    public static class GemaeldeMapper
    {
        public static GemaeldeDto ToGemaeldeDto(this Gemaelde gemaeldeModel)
        {
            return new GemaeldeDto
            {
                Id = gemaeldeModel.Id,
                Name = gemaeldeModel.Name,
                Kommentare = gemaeldeModel.Kommentare.Select(b => b.ToKommentarDto()).ToList()
            };
        }

        public static Gemaelde ToGemaeldeFromCreateDto(this CreateGemaeldeDto createGemaeldeDto)
        {
            return new Gemaelde
            {
                Name = createGemaeldeDto.Name
            };
        }
    }
}


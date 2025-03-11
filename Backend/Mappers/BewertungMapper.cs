using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Bewertungen;
using Backend.Models;

namespace Backend.Mappers
{
    public static class BewertungMapper
    {
        public static BewertungDto ToBewertungDto(this Bewertung bewertungModel)
        {
            return new BewertungDto
            {
                Id = bewertungModel.Id,
                Note = bewertungModel.Note,
                Kommentar = bewertungModel.Kommentar,
                GepostetVon = bewertungModel.GepostetVon,
                GemaeldeId = bewertungModel.GemaeldeId
            };
        }

        public static Bewertung ToBewertungFromCreateDto(this CreateBewertungDto createBewertungDto, int gemaeldeId)
        {
            return new Bewertung
            {
                Note = createBewertungDto.Note,
                Kommentar = createBewertungDto.Kommentar,
                GepostetVon = createBewertungDto.GepostetVon,
                GemaeldeId = gemaeldeId
            };
        }

        public static Bewertung ToBewertungFromUpdateDto(this UpdateBewertungDto updateBewertungDto)
        {
            return new Bewertung
            {
                Note = updateBewertungDto.Note,
                Kommentar = updateBewertungDto.Kommentar,
                GepostetVon = updateBewertungDto.GepostetVon
            };
        }
    }
}
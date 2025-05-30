using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Kommentare;
using Backend.Models;

namespace Backend.Mappers
{
    public static class KommentarMapper
    {
        public static KommentarDto ToKommentarDto(this Kommentar kommentarModel)
        {
            return new KommentarDto
            {
                Id = kommentarModel.Id,
                Note = kommentarModel.Note,
                Inhalt = kommentarModel.Inhalt,
                GepostetVon = kommentarModel.GepostetVon,
                GemaeldeId = kommentarModel.GemaeldeId
            };
        }

        public static Kommentar ToKommentarFromCreateDto(this CreateKommentarDto createKommentarDto, int gemaeldeId)
        {
            return new Kommentar
            {
                Note = createKommentarDto.Note,
                Inhalt = createKommentarDto.Inhalt,
                GepostetVon = createKommentarDto.GepostetVon,
                GemaeldeId = gemaeldeId
            };
        }

        public static Kommentar ToKommentarFromUpdateDto(this UpdateKommentarDto updateKommentarDto)
        {
            return new Kommentar
            {
                Note = updateKommentarDto.Note,
                Inhalt = updateKommentarDto.Inhalt,
            };
        }
    }
}
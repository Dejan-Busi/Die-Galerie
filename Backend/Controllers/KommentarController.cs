using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Kommentare;
using Backend.Mappers;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/kommentar")]
    public class KommentarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KommentarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------------------

        [Authorize]
        [HttpPost("{gemaeldeId}")]
        public async Task<IActionResult> Create([FromRoute] int gemaeldeId, CreateKommentarDto createKommentarDto)
        {
            var gepostetVon = User.FindFirst(ClaimTypes.Email)?.Value;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gemaeldeExists = await _context.Gemaelder.AnyAsync(s => s.Id == gemaeldeId);

            if (gemaeldeExists == false)
            {
                return BadRequest("Das gesuchte Gemälde existiert nicht.");
            }

            createKommentarDto.GepostetVon = gepostetVon;

            var kommentarToPost = createKommentarDto.ToKommentarFromCreateDto(gemaeldeId);

            await _context.Kommentare.AddAsync(kommentarToPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByBewertungId), new { id = kommentarToPost.Id }, kommentarToPost.ToKommentarDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kommentar = await _context.Kommentare.ToListAsync();

            return Ok(kommentar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBewertungId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kommentar = await _context.Kommentare.FindAsync(id);

            if (kommentar == null)
            {
                return NotFound("Die gesuchte Bewertung wurde nicht gefunden.");
            }

            return Ok(kommentar);
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateKommentarDto updateDto)
        {
            var gepostetVon = User.FindFirst(ClaimTypes.Email)?.Value;

            var updatedComment = updateDto.ToKommentarFromUpdateDto();
            var kommentarToUpdate = await _context.Kommentare.FirstOrDefaultAsync(x => x.Id == id);

            if (kommentarToUpdate.GepostetVon != gepostetVon)
            {
                return Unauthorized("Du bist nicht dafür authorisiert.");
            }

            if (kommentarToUpdate == null)
            {
                return NotFound("Der gesuchte Kommentar wurde nicht gefunden.");
            }

            kommentarToUpdate.Note = updatedComment.Note;
            kommentarToUpdate.Inhalt = updatedComment.Inhalt;

            await _context.SaveChangesAsync();

            return Ok(kommentarToUpdate.ToKommentarDto());
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var gepostetVon = User.FindFirst(ClaimTypes.Email)?.Value;

            var kommentarToDelete = await _context.Kommentare.FirstOrDefaultAsync(x => x.Id == id);
            {
                if (kommentarToDelete.GepostetVon != gepostetVon)
                {
                    return Unauthorized("Du bist nicht dafür authorisiert.");
                }

                if (kommentarToDelete == null)
                {
                    return NotFound("Der gesuchte Eintrag wurde nicht gefunden.");
                }

                _context.Kommentare.Remove(kommentarToDelete);

                await _context.SaveChangesAsync();

                return Ok("Der Eintrag wurde erfolgreich gelöscht.");
            }
        }
    }
}
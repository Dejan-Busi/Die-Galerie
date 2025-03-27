using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Bewertungen;
using Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/bewertung")]
    public class BewertungController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BewertungController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------------------------------------

        [HttpPost("{gemaeldeId}")]
        public async Task<IActionResult> Create([FromRoute] int gemaeldeId, CreateBewertungDto createBewertungDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gemaeldeExists = await _context.Gemaelder.AnyAsync(s => s.Id == gemaeldeId);

            if (gemaeldeExists == false)
            {
                return BadRequest("Das gesuchte Gemälde existiert nicht.");
            }

            var bewertungToPost = createBewertungDto.ToBewertungFromCreateDto(gemaeldeId);

            await _context.Bewertungen.AddAsync(bewertungToPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByBewertungId), new { id = bewertungToPost.Id }, bewertungToPost.ToBewertungDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bewertungen = await _context.Bewertungen.ToListAsync();

            return Ok(bewertungen);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBewertungId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bewertung = await _context.Bewertungen.FindAsync(id);

            if (bewertung == null)
            {
                return NotFound();
            }

            return Ok(bewertung);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bewertungToDelete = await _context.Bewertungen.FirstOrDefaultAsync(x => x.Id == id);
            {
                if (bewertungToDelete == null)
                {
                    return NotFound();
                }

                _context.Bewertungen.Remove(bewertungToDelete);

                await _context.SaveChangesAsync();

                return Ok("Der Eintrag wurde gelöscht.");
            }
        }
    }
}


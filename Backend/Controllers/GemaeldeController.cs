using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Gemaelde;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/gemaelde")]
    public class GemaeldeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public GemaeldeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGemaeldeDto gemaeldeDto)
        {
            var gemaeldeToCreate = gemaeldeDto.ToGemaeldeFromCreateDto();
            await _context.Gemaelder.AddAsync(gemaeldeToCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = gemaeldeToCreate.Id }, gemaeldeToCreate.ToGemaeldeDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gemaelder = await _context.Gemaelder.Include(b => b.Kommentare).ToListAsync();

            var gemaelderDto = gemaelder.Select(s => s.ToGemaeldeDto());

            return Ok(gemaelderDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var gemaelde = await _context.Gemaelder.Include(b => b.Kommentare).ToListAsync();

            if (gemaelde == null)
            {
                return NotFound();
            }

            return Ok(gemaelde);
        }
    }
}


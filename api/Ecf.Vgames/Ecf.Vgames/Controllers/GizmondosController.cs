﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecf.Vgames.Database;
using Ecf.Vgames.Models;

namespace Ecf.Vgames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GizmondosController : ControllerBase
    {
        private readonly GizmondosDbContext _context;

        public GizmondosController(GizmondosDbContext context)
        {
            _context = context;
        }

        // GET: api/Gizmondos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gizmondo>>> GetGizmondo()
        {
            return await _context.Gizmondo.ToListAsync();
        }

        // GET: api/Gizmondos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gizmondo>> GetGizmondo(int id)
        {
            var gizmondo = await _context.Gizmondo.FindAsync(id);

            if (gizmondo == null)
            {
                return NotFound();
            }

            return gizmondo;
        }

        // PUT: api/Gizmondos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGizmondo(int id, Gizmondo gizmondo)
        {
            if (id != gizmondo.Id)
            {
                return BadRequest();
            }

            _context.Entry(gizmondo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GizmondoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Gizmondos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gizmondo>> PostGizmondo(Gizmondo gizmondo)
        {
            _context.Gizmondo.Add(gizmondo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGizmondo", new { id = gizmondo.Id }, gizmondo);
        }

        // DELETE: api/Gizmondos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGizmondo(int id)
        {
            var gizmondo = await _context.Gizmondo.FindAsync(id);
            if (gizmondo == null)
            {
                return NotFound();
            }

            _context.Gizmondo.Remove(gizmondo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GizmondoExists(int id)
        {
            return _context.Gizmondo.Any(e => e.Id == id);
        }
    }
}

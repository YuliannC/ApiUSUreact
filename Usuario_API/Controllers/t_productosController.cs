using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Usuario_API;
using Usuario_API.Models;

namespace Usuario_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_productosController : ControllerBase
    {
        private readonly usuarioDbContext _context;

        public t_productosController(usuarioDbContext context)
        {
            _context = context;
        }

        // GET: api/t_producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_producto>>> Gett_producto()
        {
          if (_context.t_producto == null)
          {
              return NotFound();
          }
            return await _context.t_producto.ToListAsync();
        }

        // GET: api/t_producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<t_producto>> Gett_producto(int id)
        {
          if (_context.t_producto == null)
          {
              return NotFound();
          }
            var t_producto = await _context.t_producto.FindAsync(id);

            if (t_producto == null)
            {
                return NotFound();
            }

            return t_producto;
        }

        // PUT: api/t_producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putt_producto(int id, t_producto t_producto)
        {
            if (id != t_producto.pro_id)
            {
                return BadRequest();
            }

            _context.Entry(t_producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_productoExists(id))
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

        // POST: api/t_producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<t_producto>> Postt_producto(t_producto t_producto)
        {
          if (_context.t_producto == null)
          {
              return Problem("Entity set 'usuarioDbContext.t_producto'  is null.");
          }
            _context.t_producto.Add(t_producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gett_producto", new { id = t_producto.pro_id }, t_producto);
        }

        // DELETE: api/t_producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet_producto(int id)
        {
            if (_context.t_producto == null)
            {
                return NotFound();
            }
            var t_producto = await _context.t_producto.FindAsync(id);
            if (t_producto == null)
            {
                return NotFound();
            }

            _context.t_producto.Remove(t_producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool t_productoExists(int id)
        {
            return (_context.t_producto?.Any(e => e.pro_id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMeta.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiMeta.Controllers
{
    [Route("api/[controller]")]
    public class ContatoController : Controller
    {
        private readonly Context _context;

        public ContatoController(Context context)
        {
            _context = context;

            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Contato { Nome = "Item1", Canal = "Bla bla bla" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContacts()
        {
            return await _context.Contatos.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContactById(string id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }

        [HttpPost]
        public IActionResult PostContact([FromBody] Contato item)
        {
            _context.Contatos.Add(item);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult PutContact(string id, Contato item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContat(string id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

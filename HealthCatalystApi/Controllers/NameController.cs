using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthCatalystApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCatalystApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NameController : ControllerBase
    {
            private readonly NameContext _context;

            public NameController(NameContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Name>>> GetNames()
            {
                return await _context.Names.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Name>> GetName(long id)
            {
                var name = await _context.Names.FindAsync(id);

                if (name == null)
                {
                    return NotFound();
                }

                return name;
            }

            [HttpPost]
            public async Task<ActionResult<Name>> PostName(Name name)
            {
                _context.Names.Add(name);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetName), new { id = name.ID }, name);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTodoItem(long id)
            {
                var name = await _context.Names.FindAsync(id);

                if (name == null)
                {
                    return NotFound();
                }

                _context.Names.Remove(name);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }


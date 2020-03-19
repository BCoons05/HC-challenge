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
    public class UserController : ControllerBase
    {
            private readonly UserContext _context;

            public UserController(UserContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            {
                return await _context.Users.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<User>> GetUser(long id)
            {
                var name = await _context.Users.FindAsync(id);

                if (name == null)
                {
                    return NotFound();
                }

                return name;
            }

            [HttpPost]
            public async Task<ActionResult<User>> PostUser(User user)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(long id)
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }


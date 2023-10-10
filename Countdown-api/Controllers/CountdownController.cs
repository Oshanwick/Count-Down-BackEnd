using Countdown_api.Data;
using Countdown_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countdown_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountdownController : ControllerBase
    {
        private readonly CountdownContext _context;

        public CountdownController(CountdownContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountDown>>> GetCountdowns()
        {
            return await _context.Countdowns.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountDown>> GetCountdown(int id)
        {
            var countdown = await _context.Countdowns.FindAsync(id);

            if (countdown == null)
            {
                return NotFound();
            }

            return countdown;
        }

        [HttpPost]
        public async Task<ActionResult<CountDown>> PostCountdown(CountDown countdown)
        {
            _context.Countdowns.Add(countdown);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountdown", new { id = countdown.Id }, countdown);
        }
        // ... CRUD actions using _context
    }
}

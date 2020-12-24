using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventool.Data;
using Eventool.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Eventool.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Reservation
        [Authorize]
        public async Task<IActionResult> Reserve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.Include(m => m.Platform).Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var recerv = await _context.Reservations.Include(m => m.EventEntity).Include(m => m.Visitor)
             .FirstOrDefaultAsync(m => m.EventEntityId == id && m.VisitorId == userId);
            var freePlaces = @event.Platform.Capacity - (await _context.Reservations.Where(r => r.EventEntityId == @event.Id).CountAsync());
            if (recerv == null)
            {
                var reservetion = new Reservation
                {
                    VisitorId = userId,
                    EventEntityId = (int)id
                };
                _context.Reservations.Add(reservetion);
                await _context.SaveChangesAsync();
                ViewData["result"] = $"You have been successfully registered to the {@event.Name}!";
                ViewData["ticket"] = $"Your ticket is: {userId + id}";
                return View();
            }
            ViewData["result"] = $"You already have been registered to the {@event.Name}!";
            ViewData["ticket"] = $"Your ticket is: {userId + id}";
            return View();
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.Include(m => m.Platform).Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewData["freePlaces"] = @event.Platform.Capacity - (await _context.Reservations.Where(r => r.EventEntityId == @event.Id).CountAsync());
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["organizations"] = await _context.Organizations.Where(x=>x.Admin.Id == userId).ToListAsync();
            ViewData["platforms"] = await _context.Platforms.ToListAsync();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Platform,Organization,Name,From,To")] CreateEventVM vm)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
                var organization = await _context.Organizations.FindAsync(vm.Organization);
                var platform = await _context.Platforms.FindAsync(vm.Platform);

                var @event = new EventEntity
                {
                    Name = vm.Name,
                    Organization = organization,
                    Platform = platform,
                    From = vm.From,
                    To = vm.To
                };
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,From,To")] EventEntity @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}

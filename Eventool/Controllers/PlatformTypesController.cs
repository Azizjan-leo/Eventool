using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eventool.Data;
using Eventool.Models;
using Microsoft.AspNetCore.Authorization;

namespace Eventool.Controllers
{
    [Authorize(Policy = "writepolicy")]
    public class PlatformTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatformTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlatformTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlatformTypes.ToListAsync());
        }

        // GET: PlatformTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformType = await _context.PlatformTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platformType == null)
            {
                return NotFound();
            }

            return View(platformType);
        }

        // GET: PlatformTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlatformTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PlatformType platformType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platformType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platformType);
        }

        // GET: PlatformTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformType = await _context.PlatformTypes.FindAsync(id);
            if (platformType == null)
            {
                return NotFound();
            }
            return View(platformType);
        }

        // POST: PlatformTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PlatformType platformType)
        {
            if (id != platformType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platformType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatformTypeExists(platformType.Id))
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
            return View(platformType);
        }

        // GET: PlatformTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformType = await _context.PlatformTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (platformType == null)
            {
                return NotFound();
            }

            return View(platformType);
        }

        // POST: PlatformTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platformType = await _context.PlatformTypes.FindAsync(id);
            _context.PlatformTypes.Remove(platformType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatformTypeExists(int id)
        {
            return _context.PlatformTypes.Any(e => e.Id == id);
        }
    }
}

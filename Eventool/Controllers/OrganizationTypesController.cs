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
    public class OrganizationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizationTypes
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Index()
        {
            var queryRes = await _context.OrganizationTypes.ToListAsync();
            return View(queryRes);
        }

        // GET: OrganizationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationType = await _context.OrganizationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationType == null)
            {
                return NotFound();
            }

            return View(organizationType);
        }

        // GET: OrganizationTypes/Create
        [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OrganizationType organizationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationType);
        }

        // GET: OrganizationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var t = _context.Organizations.Where(x => x.Id == 1);
            var str = t.ToQueryString();
            var organizationType = await _context.OrganizationTypes.FindAsync(id);
            if (organizationType == null)
            {
                return NotFound();
            }
            return View(organizationType);
        }

        // POST: OrganizationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OrganizationType organizationType)
        {
            if (id != organizationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationTypeExists(organizationType.Id))
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
            return View(organizationType);
        }

        // GET: OrganizationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationType = await _context.OrganizationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationType == null)
            {
                return NotFound();
            }

            return View(organizationType);
        }

        // POST: OrganizationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationType = await _context.OrganizationTypes.FindAsync(id);
            _context.OrganizationTypes.Remove(organizationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationTypeExists(int id)
        {
            return _context.OrganizationTypes.Any(e => e.Id == id);
        }
    }
}

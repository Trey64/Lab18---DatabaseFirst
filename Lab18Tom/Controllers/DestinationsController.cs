using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab18Tom.Models;

namespace Lab18Tom.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly Lab18TomContext _context;

        public DestinationsController(Lab18TomContext context)
        {
            _context = context;
        }

        // GET: Destinations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinations.ToListAsync());
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinations == null)
            {
                return NotFound();
            }

            return View(destinations);
        }

        // GET: Destinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationID,Name,Country")] Destinations destinations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinations);
        }

        // GET: Destinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations.SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinations == null)
            {
                return NotFound();
            }
            return View(destinations);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationID,Name,Country")] Destinations destinations)
        {
            if (id != destinations.DestinationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationsExists(destinations.DestinationID))
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
            return View(destinations);
        }

        // GET: Destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinations = await _context.Destinations
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinations == null)
            {
                return NotFound();
            }

            return View(destinations);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinations = await _context.Destinations.SingleOrDefaultAsync(m => m.DestinationID == id);
            _context.Destinations.Remove(destinations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationsExists(int id)
        {
            return _context.Destinations.Any(e => e.DestinationID == id);
        }
    }
}

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
    public class DestinationSuppliesController : Controller
    {
        private readonly Lab18TomContext _context;

        public DestinationSuppliesController(Lab18TomContext context)
        {
            _context = context;
        }

        // GET: DestinationSupplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinationSupplies.ToListAsync());
        }

        // GET: DestinationSupplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationSupplies = await _context.DestinationSupplies
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationSupplies == null)
            {
                return NotFound();
            }

            return View(destinationSupplies);
        }

        // GET: DestinationSupplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinationSupplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationID,SuppyID")] DestinationSupplies destinationSupplies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinationSupplies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinationSupplies);
        }

        // GET: DestinationSupplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationSupplies = await _context.DestinationSupplies.SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationSupplies == null)
            {
                return NotFound();
            }
            return View(destinationSupplies);
        }

        // POST: DestinationSupplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationID,SuppyID")] DestinationSupplies destinationSupplies)
        {
            if (id != destinationSupplies.DestinationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinationSupplies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationSuppliesExists(destinationSupplies.DestinationID))
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
            return View(destinationSupplies);
        }

        // GET: DestinationSupplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinationSupplies = await _context.DestinationSupplies
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (destinationSupplies == null)
            {
                return NotFound();
            }

            return View(destinationSupplies);
        }

        // POST: DestinationSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinationSupplies = await _context.DestinationSupplies.SingleOrDefaultAsync(m => m.DestinationID == id);
            _context.DestinationSupplies.Remove(destinationSupplies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationSuppliesExists(int id)
        {
            return _context.DestinationSupplies.Any(e => e.DestinationID == id);
        }
    }
}

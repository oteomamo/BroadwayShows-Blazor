using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;

namespace BroadwayShows.API.Controllers
{
    public class WorkingPositionsController : Controller
    {
        private readonly BroadwayShowsContext _context;

        public WorkingPositionsController(BroadwayShowsContext context)
        {
            _context = context;
        }

        // GET: WorkingPositions
        public async Task<IActionResult> Index()
        {
              return _context.WorkingPositions != null ? 
                          View(await _context.WorkingPositions.ToListAsync()) :
                          Problem("Entity set 'BroadwayShowsContext.WorkingPositions'  is null.");
        }

        // GET: WorkingPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkingPositions == null)
            {
                return NotFound();
            }

            var workingPosition = await _context.WorkingPositions
                .FirstOrDefaultAsync(m => m.WorkingPositionID == id);
            if (workingPosition == null)
            {
                return NotFound();
            }

            return View(workingPosition);
        }

        // GET: WorkingPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingPositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkingPositionID,Name")] WorkingPosition workingPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingPosition);
        }

        // GET: WorkingPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkingPositions == null)
            {
                return NotFound();
            }

            var workingPosition = await _context.WorkingPositions.FindAsync(id);
            if (workingPosition == null)
            {
                return NotFound();
            }
            return View(workingPosition);
        }

        // POST: WorkingPositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkingPositionID,Name")] WorkingPosition workingPosition)
        {
            if (id != workingPosition.WorkingPositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingPositionExists(workingPosition.WorkingPositionID))
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
            return View(workingPosition);
        }

        // GET: WorkingPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkingPositions == null)
            {
                return NotFound();
            }

            var workingPosition = await _context.WorkingPositions
                .FirstOrDefaultAsync(m => m.WorkingPositionID == id);
            if (workingPosition == null)
            {
                return NotFound();
            }

            return View(workingPosition);
        }

        // POST: WorkingPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkingPositions == null)
            {
                return Problem("Entity set 'BroadwayShowsContext.WorkingPositions'  is null.");
            }
            var workingPosition = await _context.WorkingPositions.FindAsync(id);
            if (workingPosition != null)
            {
                _context.WorkingPositions.Remove(workingPosition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingPositionExists(int id)
        {
          return (_context.WorkingPositions?.Any(e => e.WorkingPositionID == id)).GetValueOrDefault();
        }
    }
}

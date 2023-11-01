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

    public class CastCrewsController : Controller
    {
        private readonly BroadwayShowsContext _context;

        public CastCrewsController(BroadwayShowsContext context)
        {
            _context = context;
        }

        // GET: CastCrews
        public async Task<IActionResult> Index()
        {
            var broadwayShowsContext = _context.CastCrews.Include(c => c.Theater);
            return View(await broadwayShowsContext.ToListAsync());
        }

        // GET: CastCrews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CastCrews == null)
            {
                return NotFound();
            }

            var castCrew = await _context.CastCrews
                .Include(c => c.Theater)
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (castCrew == null)
            {
                return NotFound();
            }

            return View(castCrew);
        }

        // GET: CastCrews/Create
        public IActionResult Create()
        {
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address");
            return View();
        }

        // POST: CastCrews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SSN,Name,WorkingPosition,Gender,ShowId,TheaterId")] CastCrew castCrew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(castCrew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", castCrew.TheaterId);
            return View(castCrew);
        }

        // GET: CastCrews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CastCrews == null)
            {
                return NotFound();
            }

            var castCrew = await _context.CastCrews.FindAsync(id);
            if (castCrew == null)
            {
                return NotFound();
            }
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", castCrew.TheaterId);
            return View(castCrew);
        }

        // POST: CastCrews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SSN,Name,WorkingPosition,Gender,ShowId,TheaterId")] CastCrew castCrew)
        {
            if (id != castCrew.SSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(castCrew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastCrewExists(castCrew.SSN))
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
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", castCrew.TheaterId);
            return View(castCrew);
        }

        // GET: CastCrews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CastCrews == null)
            {
                return NotFound();
            }

            var castCrew = await _context.CastCrews
                .Include(c => c.Theater)
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (castCrew == null)
            {
                return NotFound();
            }

            return View(castCrew);
        }

        // POST: CastCrews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CastCrews == null)
            {
                return Problem("Entity set 'BroadwayShowsContext.CastCrews'  is null.");
            }
            var castCrew = await _context.CastCrews.FindAsync(id);
            if (castCrew != null)
            {
                _context.CastCrews.Remove(castCrew);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastCrewExists(int id)
        {
          return (_context.CastCrews?.Any(e => e.SSN == id)).GetValueOrDefault();
        }
    }
}

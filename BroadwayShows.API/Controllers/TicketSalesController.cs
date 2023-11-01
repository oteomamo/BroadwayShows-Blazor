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

    public class TicketSalesController : Controller
    {
        private readonly BroadwayShowsContext _context;

        public TicketSalesController(BroadwayShowsContext context)
        {
            _context = context;
        }

        // GET: TicketSales
        public async Task<IActionResult> Index()
        {
            var broadwayShowsContext = _context.TicketSales.Include(t => t.Theater);
            return View(await broadwayShowsContext.ToListAsync());
        }

        // GET: TicketSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketSales == null)
            {
                return NotFound();
            }

            var ticketSales = await _context.TicketSales
                .Include(t => t.Theater)
                .FirstOrDefaultAsync(m => m.TicketNumber == id);
            if (ticketSales == null)
            {
                return NotFound();
            }

            return View(ticketSales);
        }

        // GET: TicketSales/Create
        public IActionResult Create()
        {
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address");
            return View();
        }

        // POST: TicketSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketNumber,Time,Date,NumberOfTickets,Price,TheaterId")] TicketSales ticketSales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketSales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", ticketSales.TheaterId);
            return View(ticketSales);
        }

        // GET: TicketSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketSales == null)
            {
                return NotFound();
            }

            var ticketSales = await _context.TicketSales.FindAsync(id);
            if (ticketSales == null)
            {
                return NotFound();
            }
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", ticketSales.TheaterId);
            return View(ticketSales);
        }

        // POST: TicketSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketNumber,Time,Date,NumberOfTickets,Price,TheaterId")] TicketSales ticketSales)
        {
            if (id != ticketSales.TicketNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketSales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketSalesExists(ticketSales.TicketNumber))
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
            ViewData["TheaterId"] = new SelectList(_context.Theaters, "TheaterId", "Address", ticketSales.TheaterId);
            return View(ticketSales);
        }

        // GET: TicketSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketSales == null)
            {
                return NotFound();
            }

            var ticketSales = await _context.TicketSales
                .Include(t => t.Theater)
                .FirstOrDefaultAsync(m => m.TicketNumber == id);
            if (ticketSales == null)
            {
                return NotFound();
            }

            return View(ticketSales);
        }

        // POST: TicketSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketSales == null)
            {
                return Problem("Entity set 'BroadwayShowsContext.TicketSales'  is null.");
            }
            var ticketSales = await _context.TicketSales.FindAsync(id);
            if (ticketSales != null)
            {
                _context.TicketSales.Remove(ticketSales);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketSalesExists(int id)
        {
          return (_context.TicketSales?.Any(e => e.TicketNumber == id)).GetValueOrDefault();
        }
    }
}

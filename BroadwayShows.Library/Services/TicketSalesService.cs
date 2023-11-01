using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Services
{
    public class TicketSalesService
    {
        private readonly BroadwayShowsContext _context;

        public TicketSalesService(BroadwayShowsContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateShowAsync(TicketSales ticketSales)
        {
            if (ticketSales == null) throw new ArgumentNullException(nameof(ticketSales));

            _context.TicketSales.Add(ticketSales);
            await _context.SaveChangesAsync();
        }

        // Read (Get a single ticketSales by ID)
        public async Task<TicketSales> GetShowByIdAsync(int id)
        {
            return await _context.TicketSales.FindAsync(id);
        }

        // Read (Get all ticketSaless)
        public async Task<List<TicketSales>> GetAllShowsAsync()
        {
            return await _context.TicketSales.ToListAsync();
        }

        // Update
        public async Task UpdateShowAsync(TicketSales ticketSales)
        {
            if (ticketSales == null) throw new ArgumentNullException(nameof(ticketSales));

            _context.Entry(ticketSales).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteShowAsync(int id)
        {
            var ticketSalesToDelete = await _context.TicketSales.FindAsync(id);
            if (ticketSalesToDelete != null)
            {
                _context.TicketSales.Remove(ticketSalesToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TimeSpan>> GetAvailableTimesForTheaterInDateRange(int theaterId, DateTime from, DateTime till)
        {
            return await _context.TicketSales
                .Where(ts => ts.TheaterId == theaterId && ts.Date >= from && ts.Date <= till)
                .Select(ts => ts.Time)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> GetAvailableTicketsForTimeSlot(int theaterId, DateTime date, TimeSpan timeSlot)
        {
            // Fetch the ticket record for that time slot, theater, and date
            var ticketRecord = await _context.TicketSales
                                             .FirstOrDefaultAsync(ts => ts.TheaterId == theaterId && ts.Date == date && ts.Time == timeSlot);

            if (ticketRecord != null)
            {
                return ticketRecord.NumberOfTickets;
            }
            else
            {
                return 0; // No record found for that time slot
            }
        }

        public async Task<DateTime?> GetExactDateForSelectedTime(int theaterId, TimeSpan time, int requiredTickets)
        {
            var ticketRecord = await _context.TicketSales
                                             .Where(ts => ts.TheaterId == theaterId && ts.Time == time && ts.NumberOfTickets >= requiredTickets)
                                             .OrderBy(ts => ts.Date)
                                             .FirstOrDefaultAsync();

            return ticketRecord?.Date;
        }



    }
}

using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;
using Microsoft.Data.SqlClient;
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
        public async Task CreateTicketSaleAsync(TicketSales ticketSales)
        {
            if (ticketSales == null) throw new ArgumentNullException(nameof(ticketSales));

            _context.TicketSales.Add(ticketSales);
            await _context.SaveChangesAsync();
        }

        // Read (Get a single ticketSales by ID)
        public async Task<TicketSales> GetTicketSaleByIdAsync(int id)
        {
            return await _context.TicketSales.FindAsync(id);
        }

        // Read (Get all ticketSaless)
        public async Task<List<TicketSales>> GetAllTicketSaleAsync()
        {
            return await _context.TicketSales.ToListAsync();
        }

        // Update
        public async Task UpdateTicketSaleAsync(TicketSales ticketSales)
        {
            if (ticketSales == null) throw new ArgumentNullException(nameof(ticketSales));

            _context.Entry(ticketSales).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteTicketSaleAsync(int id)
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

        public async Task<TicketSales> GetTicketSalesByIdAsync(int theaterId, DateTime date, TimeSpan time)
        {
            return await _context.TicketSales
                                 .Where(ts => ts.TheaterId == theaterId && ts.Date.Date == date.Date && ts.Time == time)
                                 .FirstOrDefaultAsync();
        }

        public async Task<TicketSales> GetTicketSalesForShowAsync(int theaterId, DateTime date, TimeSpan time)
        {
            return await _context.TicketSales
                .FirstOrDefaultAsync(ts => ts.TheaterId == theaterId && ts.Date.Date == date.Date && ts.Time == time);
        }

        public async Task CreateTicketSale2Async(TicketSales ticketSales)
        {
            if (ticketSales == null) throw new ArgumentNullException(nameof(ticketSales));

            var existingTicketSales = await _context.TicketSales
                                                    .FirstOrDefaultAsync(ts => ts.Date == ticketSales.Date
                                                                                && ts.Time == ticketSales.Time
                                                                                && ts.TheaterId == ticketSales.TheaterId);

            int existingTicketNumber = existingTicketSales?.TicketNumber ?? 0;

            if ((existingTicketNumber + ticketSales.TicketNumber) > ticketSales.NumberOfTickets)
            {
                throw new InvalidOperationException("The number of tickets exceeds the available tickets for this time slot.");
            }

            _context.TicketSales.Add(ticketSales);
            await _context.SaveChangesAsync();
        }


        public async Task RemoveTicketsAsync(int ticketNumber, int numberOfTicketsToRemove)
        {
            var existingTicket = await _context.TicketSales
                                               .Where(ts => ts.TicketNumber == ticketNumber)
                                               .FirstOrDefaultAsync();

            if (existingTicket != null)
            {
                if (existingTicket.NumberOfTickets >= numberOfTicketsToRemove)
                {
                    existingTicket.NumberOfTickets -= numberOfTicketsToRemove;
                    _context.Entry(existingTicket).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Not enough tickets to remove.");
                }
            }
            else
            {
                throw new Exception("Ticket number not found.");
            }
        }


    }
}

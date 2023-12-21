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

        public async Task<TicketSales> GetTicketSaleByIdAsync(int id)
        {
            return await _context.TicketSales.FindAsync(id);
        }

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
            var ticketRecord = await _context.TicketSales
                                             .FirstOrDefaultAsync(ts => ts.TheaterId == theaterId && ts.Date == date && ts.Time == timeSlot);

            if (ticketRecord != null)
            {
                return ticketRecord.NumberOfTickets;
            }
            else
            {
                return 0; 
            }
        }

        public async Task<decimal> GetTicketPriceForShow(int showId)
        {
            // This query assumes that each show has tickets available at the theater listed in the castcrews table
            // and that you want the price of any ticket for that show at that theater.
            var ticketPrice = await _context.TicketSales
                .Join(_context.CastCrews,
                      ts => ts.TheaterId,
                      cc => cc.TheaterId,
                      (ts, cc) => new { TicketSales = ts, CastCrews = cc })
                .Where(joined => joined.CastCrews.ShowId == showId)
                .Select(joined => joined.TicketSales.Price)
                .FirstOrDefaultAsync(); // Gets the price of the first ticket found

            return ticketPrice; // This will be null if no matching tickets are found
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
                                 .Where(ts => ts.TheaterId == theaterId && ts.Date == date && ts.Time == time)
                                 .FirstOrDefaultAsync();
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

        public async Task<List<TimeSpan>> GetAvailableTimesForShow(int showId, DateTime from, DateTime till)
        {
            // First, find the TheaterId(s) for the show from the castcrews table.
            var theaterIdsForShow = await _context.CastCrews
                .Where(cc => cc.ShowId == showId)
                .Select(cc => cc.TheaterId)
                .Distinct()
                .ToListAsync();

            // Now, fetch the available times for these theaters from the ticketsales table within the date range.
            var availableTimes = await _context.TicketSales
                .Where(ts => theaterIdsForShow.Contains(ts.TheaterId) && ts.Date >= from && ts.Date <= till)
                .Select(ts => ts.Time)
                .Distinct()
                .ToListAsync();

            return availableTimes;
        }


    }
}

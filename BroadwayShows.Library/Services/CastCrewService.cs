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
    public class CastCrewService
    {
        private readonly BroadwayShowsContext _context;

        public CastCrewService(BroadwayShowsContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateShowAsync(CastCrew castCrew)
        {
            if (castCrew == null) throw new ArgumentNullException(nameof(castCrew));

            _context.CastCrews.Add(castCrew);
            await _context.SaveChangesAsync();
        }

        // Read (Get a single castCrew by ID)
        public async Task<CastCrew> GetShowByIdAsync(int id)
        {
            return await _context.CastCrews.FindAsync(id);
        }

        // Read (Get all castCrews)
        public async Task<List<CastCrew>> GetAllShowsAsync()
        {
            return await _context.CastCrews.ToListAsync();
        }

        // Update
        public async Task UpdateShowAsync(CastCrew castCrew)
        {
            if (castCrew == null) throw new ArgumentNullException(nameof(castCrew));

            _context.Entry(castCrew).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteShowAsync(int id)
        {
            var castCrewToDelete = await _context.CastCrews.FindAsync(id);
            if (castCrewToDelete != null)
            {
                _context.CastCrews.Remove(castCrewToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

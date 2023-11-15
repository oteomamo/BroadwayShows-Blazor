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
        public async Task CreateCastCrewAsync(CastCrew castCrew)
        {
            if (castCrew == null) throw new ArgumentNullException(nameof(castCrew));
            castCrew.SSN = await GenerateUniqueSSN();
            _context.CastCrews.Add(castCrew);
            await _context.SaveChangesAsync();
        }

        // Read (Get a single castCrew by ID)
        public async Task<CastCrew> GetCastCrewByIdAsync(int id)
        {
            return await _context.CastCrews.FindAsync(id);
        }

        // Read (Get all castCrews)
        public async Task<List<CastCrew>> GetAllCastCrewsAsync()
        {
            return await _context.CastCrews.ToListAsync();
        }

        // Update
        public async Task UpdateCastCrewAsync(CastCrew castCrew)
        {
            if (castCrew == null) throw new ArgumentNullException(nameof(castCrew));

            _context.Entry(castCrew).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteCastCrewAsync(int id)
        {
            var castCrewToDelete = await _context.CastCrews.FindAsync(id);
            if (castCrewToDelete != null)
            {
                _context.CastCrews.Remove(castCrewToDelete);
                await _context.SaveChangesAsync();
            }
        }

/*        public async Task<List<string>> SearchPositionsAsync(string search)
        {
*//*            if (string.IsNullOrEmpty(search))
            {
                return new List<string>();
            }

            return await _context.CastCrews
                .Where(cc => cc.WorkingPosition.Contains(search))
                .Select(cc => cc.WorkingPosition)
                .Distinct()
                .ToListAsync();*//*
        }*/
        private async Task<int> GenerateUniqueSSN()
        {
            var random = new Random();
            int uniqueSSN;
            do
            {
                uniqueSSN = random.Next(100000000, 1000000000); 
            }
            while (await _context.CastCrews.AnyAsync(cc => cc.SSN == uniqueSSN));

            return uniqueSSN;
        }
/*        public async Task<List<string>> GetAllDistinctPositionsAsync()
        {
            return await _context.CastCrews
                .Select(cc => cc.WorkingPosition)
                .Distinct()
                .ToListAsync();
        }*/
        public async Task<List<CastCrew>> SearchCastCrewAsync(string showName, string position, char gender)
        {
            var query = _context.CastCrews.Include(cc => cc.Show).AsQueryable();

            if (!string.IsNullOrEmpty(showName) && showName != "all")
                query = query.Where(cc => cc.Show.Name == showName);

           /* if (!string.IsNullOrEmpty(position) && position != "all")
                query = query.Where(cc => cc.WorkingPosition == position);*/

            if (gender != '\0')
                query = query.Where(cc => cc.Gender == gender);

            return await query.ToListAsync();
        }

/*        public async Task<List<string>> GetAllCastCrewsPositionAsync()
        {
            return await _context.CastCrews.Select(CastCrew => CastCrew.WorkingPosition).Distinct().ToListAsync();
        }*/

        public async Task<bool> IsShowScheduledAtTheater(int showId, int theaterId)
        {
            var castCrewRecord = await _context.CastCrews
                                                .AnyAsync(cc => cc.ShowId == showId && cc.TheaterId == theaterId);
            return castCrewRecord;
        }

        public async Task<List<int>> GetTheatersForShow(int showId)
        {
            return await _context.CastCrews
                .Where(cc => cc.ShowId == showId)
                .Select(cc => cc.TheaterId)
                .Distinct()
                .ToListAsync();
        }
    }



}

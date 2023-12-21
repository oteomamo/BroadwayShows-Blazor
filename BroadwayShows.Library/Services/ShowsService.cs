using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BroadwayShows.Library.Services
{
    public class ShowsService
    {
        private readonly BroadwayShowsContext _context;

        private readonly CastCrewService _castCrewService;

        public ShowsService(BroadwayShowsContext context, CastCrewService castCrewService)
        {
            _context = context;
            _castCrewService = castCrewService;
        }


        public ShowsService(BroadwayShowsContext context)
        {
            _context = context;
        }

        public async Task CreateShowAsync(Shows show)
        {
            if (show == null) throw new ArgumentNullException(nameof(show));

            _context.Shows.Add(show);
            await _context.SaveChangesAsync();
        }


        // Read (Get a single show by ID)
        public async Task<Shows> GetShowByIdAsync(int id)
        {
            return await _context.Shows.FindAsync(id);
        }

        // Read (Get all shows)
        public async Task<List<Shows>> GetAllShowsAsync()
        {
            return await _context.Shows.ToListAsync();
        }

        // Update
        public async Task UpdateShowAsync(Shows show)
        {
            if (show == null) throw new ArgumentNullException(nameof(show));

            _context.Entry(show).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteShowAsync(int id)
        {
            var showToDelete = await _context.Shows.FindAsync(id);
            if (showToDelete != null)
            {
                _context.Shows.Remove(showToDelete);
                await _context.SaveChangesAsync();
            }
        }

        // Read (Get all show names)
        public async Task<List<string>> GetShowNamesAsync()
        {
            return await _context.Shows.Select(show => show.Name).ToListAsync();
        }

        public async Task<List<(string Name, string Image)>> GetShowNamesAndImagesAsync()
        {
            return await _context.Shows
                       .Select(show => new { show.Name, show.Image })
                       .ToListAsync()
                       .ContinueWith(task => task.Result
                                                .Select(result => (result.Name, result.Image))
                                                .ToList());
        }

        public async Task<List<(int Id, string Name, string Image)>> GetShowIdNamesAndImagesAsync()
        {
            return await _context.Shows
                       .Select(show => new { show.ShowId, show.Name, show.Image })
                       .ToListAsync()
                       .ContinueWith(task => task.Result
                                                .Select(result => (result.ShowId, result.Name, result.Image))
                                                .ToList());
        }
        public async Task<int> GetShowIdByName(string showName)
        {
            var show = await _context.Shows.FirstOrDefaultAsync(s => s.Name == showName);
            return show.ShowId;
        }


        public async Task<List<string>> GetTheatersForShowAsync(int showId)
        {
            if (showId == -1)
            {
                return await _context.Theaters
                                     .Select(theater => theater.Name)
                                     .ToListAsync();
            }
            else
            {
                return await _context.CastCrews
                                     .Where(cc => cc.ShowId == showId)
                                     .Join(_context.Theaters,
                                           cc => cc.TheaterId,
                                           theater => theater.TheaterId,
                                           (cc, theater) => theater.Name)
                                     .Distinct()
                                     .ToListAsync();
            }
        }

        public async Task<List<string>> GetTheatersForShowNameAsync(string showName)
        {
            var showId = await _context.Shows
                                       .Where(show => show.Name == showName)
                                       .Select(show => show.ShowId)
                                       .FirstOrDefaultAsync();

            if (showId == 0)
            {
                return new List<string>();
            }

            return await _context.CastCrews
                                 .Where(cc => cc.ShowId == showId)
                                 .Join(_context.Theaters,
                                       cc => cc.TheaterId,
                                       theater => theater.TheaterId,
                                       (cc, theater) => theater.Name)
                                 .Distinct()
                                 .ToListAsync();
        }
        /*        public async Task<List<string>> SearchGenresAsync(string search)
                {
        *//*            if (string.IsNullOrEmpty(search))
                    {
                        return new List<string>();
                    }

                    return await _context.Shows
                        .Where(s => s.Genre.Contains(search))
                        .Select(s => s.Genre)
                        .Distinct()
                        .ToListAsync();*//*
                }*/

        public async Task<List<Shows>> GetShowsByGenresAsync(List<int> genreIds)
        {
            if (genreIds == null || !genreIds.Any())
            {
                // Return all shows if no specific genre is selected
                return await GetAllShowsAsync();
            }

            return await _context.Shows
                                 .Where(show => genreIds.Contains(show.GenreId))
                                 .ToListAsync();
        }

    }
}

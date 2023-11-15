using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BroadwayShows.Library.Services
{


    public class GenreService
    {
        private readonly BroadwayShowsContext _context;

        public GenreService(BroadwayShowsContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateGenreAsync(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }


        public async Task<Genre> GetGenresByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        // Update
        public async Task UpdateGenresAsync(Genre genre)
        {
            if (genre == null) throw new ArgumentNullException(nameof(genre));

            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteGenresAsync(int id)
        {
            var genreToDelete = await _context.Genres.FindAsync(id);
            if (genreToDelete != null)
            {
                _context.Genres.Remove(genreToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

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
    public class WorkingPositionService
    {

        private readonly BroadwayShowsContext _context;

        public WorkingPositionService(BroadwayShowsContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateWorkingPositionAsync(WorkingPosition workingPosition)
        {
            if (workingPosition == null)
                throw new ArgumentNullException(nameof(workingPosition));

            _context.WorkingPositions.Add(workingPosition);
            await _context.SaveChangesAsync();
        }


        public async Task<WorkingPosition> GetWorkingPositionsByIdAsync(int id)
        {
            return await _context.WorkingPositions.FindAsync(id);
        }

        public async Task<List<WorkingPosition>> GetAllWorkingPositionsAsync()
        {
            return await _context.WorkingPositions.ToListAsync();
        }

        // Update
        public async Task UpdateWorkingPositionsAsync(WorkingPosition workingPosition)
        {
            if (workingPosition == null) throw new ArgumentNullException(nameof(workingPosition));

            _context.Entry(workingPosition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteShowAsync(int id)
        {
            var workingPositionToDelete = await _context.WorkingPositions.FindAsync(id);
            if (workingPositionToDelete != null)
            {
                _context.WorkingPositions.Remove(workingPositionToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}


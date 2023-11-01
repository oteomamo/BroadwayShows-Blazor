using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Models
{
    public class CastCrew
    {
        public CastCrew()
        {
            // Initialize any defaults or collections if needed in the future
        }

        public int SSN { get; set; }
        public string Name { get; set; }
        public string WorkingPosition { get; set; }
        public char Gender { get; set; }
        public int ShowId { get; set; }
        public int TheaterId { get; set; }
        public Shows Shows { get; set; }
        public Theater Theater { get; set; }
    }


}

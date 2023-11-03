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
        }

        public int SSN { get; set; }
        public string Name { get; set; }
        public string WorkingPosition { get; set; }
        public char Gender { get; set; }
        public int ShowId { get; set; }
        public int TheaterId { get; set; }
        public Shows Show { get; set; }
        public Theater Theater { get; set; }
    }


}

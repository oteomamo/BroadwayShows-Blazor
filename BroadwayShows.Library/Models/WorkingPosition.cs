using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Models
{
    public class WorkingPosition
    {
        public int WorkingPositionID { get; set; }
        public string Name { get; set; }
        public ICollection<CastCrew> CastCrews { get; set; }
    }
}

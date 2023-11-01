using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Models
{
    public class Shows
    {
        public Shows()
        {
            CastCrews = new List<CastCrew>();
        }

        public int ShowId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Image {  get; set; }
        public ICollection<CastCrew> CastCrews { get; set; }
    }


}

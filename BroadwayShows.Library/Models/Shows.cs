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
        public DateOnly ReleaseDate { get; set; }
        public string? Image {  get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<CastCrew> CastCrews { get; set; }
    }


}

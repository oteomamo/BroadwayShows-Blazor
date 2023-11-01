using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Models
{
    public class Theater
    {
        public Theater()
        {
            TicketSales = new List<TicketSales>();
            CastCrews = new List<CastCrew>();
        }

        public int TheaterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfSeats { get; set; }
        public ICollection<TicketSales> TicketSales { get; set; }
        public ICollection<CastCrew> CastCrews { get; set; }
    }


}

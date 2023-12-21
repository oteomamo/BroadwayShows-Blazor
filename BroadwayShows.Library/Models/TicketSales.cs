using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Models
{
    public class TicketSales
    {
        public TicketSales()
        {

        }

        public int TicketNumber { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal Price { get; set; }
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        public int ShowId { get; set; } 
        public Shows Show { get; set; }
    }


}

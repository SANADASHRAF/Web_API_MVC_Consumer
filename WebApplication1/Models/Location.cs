using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string location { get; set; }
        public double Distance  { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        // option 1 
        public int? TrainNumber { get; set; }
        public int? TicketNumber { get; set; }
        //option 2 
        public ICollection<Ticket> Ticket { get; set; } 


        public ICollection<User> users { get; set; } 

    }
}

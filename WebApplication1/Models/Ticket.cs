using Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public int? NumOfSeat { get; set; } = 0;
        public DateTime TakeOffDate { get; set; } = DateTime.Now;
        public string TakeOffStation { get; set; }
        public string ArrivalStation { get; set; }
        public double Price { get; set; }
        public bool ScanedOrNot { get; set; }
        public string TrainDegree { get; set; }



        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public virtual User User { get; set; }


        [ForeignKey(nameof(payment))]
        public int? PaymentId { get; set; }
        public virtual Payment payment { get; set; }



        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }



    }
}

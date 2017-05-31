using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
   public class Tour
    {
       public string Name { get; set; }

       public DateTime TourDate { get; set; }

       public int NbrOfSeats { get; set; }

       public Tour()
       {
           
       }
       public Tour(string name, DateTime tourDate, int nbrOfSeats)
       {
           this.Name = name;
           this.TourDate = tourDate;
           this.NbrOfSeats = nbrOfSeats;
       }
    }
}

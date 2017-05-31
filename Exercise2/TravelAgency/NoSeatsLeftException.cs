using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
  public class NoSeatsLeftException: Exception
    {
        public override string Message { get; }
      public NoSeatsLeftException(Tour tour)
      {
          Message = $"Sorry the tour {tour} has no seats left";
      }
    }
}

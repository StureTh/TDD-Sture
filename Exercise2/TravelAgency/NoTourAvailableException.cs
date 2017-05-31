using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
   public class NoTourAvailableException: Exception
    {
        public override string Message { get;}
       public NoTourAvailableException(string name, DateTime date)
       {
           Message = $"Sorry this tour is not available: {name}     {date}";
       }


       
    }
}

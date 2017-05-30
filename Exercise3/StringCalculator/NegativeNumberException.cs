using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator
{
   public class NegativeNumberException: Exception
    {
       public override string Message { get; }  

     

       public NegativeNumberException( List<int> negativeNumbers)
       {
           var nstring = string.Join(",", negativeNumbers);
           Message = "Negative numbers is not allowed" + nstring;

       }

    
       

      
    }
}

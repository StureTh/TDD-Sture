using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ValidationEngine
{
   public class Validator
    {
        public bool ValidateEmailAddress(string email)
        {
             var regex = new Regex(@"^([\D]+)@([\D]+)((\.(\D){2,3})+)$");

           
           

            return regex.IsMatch(email);
        }
        
    }
}

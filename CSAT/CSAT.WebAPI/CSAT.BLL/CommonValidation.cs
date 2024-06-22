using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL
{
   public  class CommonValidation
    {
        public static bool MinIntValidation(int value)
        {
            return !(value > 0);   
        }

        public static bool stringValidation(string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}

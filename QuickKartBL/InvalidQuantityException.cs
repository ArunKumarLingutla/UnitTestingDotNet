using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
        {
            
        }
        public InvalidQuantityException(string message):base(message)
        {
            
        }
    }
}

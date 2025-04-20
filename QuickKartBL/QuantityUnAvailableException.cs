using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class QuantityUnAvailableException : Exception
    {
        public QuantityUnAvailableException()
        {
            
        }
        public QuantityUnAvailableException(string message):base(message)
        {
            
        }
    }
}

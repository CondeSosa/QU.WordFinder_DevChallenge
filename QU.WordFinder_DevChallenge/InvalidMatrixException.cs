using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordFinder_DevChallenge
{
    public class InvalidMatrixException  : Exception
    {
        public InvalidMatrixException() : base("The provided matrix is invalid.") 
        {
        }
    }
}

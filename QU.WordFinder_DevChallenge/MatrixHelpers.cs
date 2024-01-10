using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordFinder_DevChallenge
{
    public static class MatrixHelpers
    {
        public static bool IsMatrixValid(this IEnumerable<string> matrix)
        {
            // Check if any string is null or empty:
            if (matrix.Any(string.IsNullOrEmpty))
            {
                return false;
            }

            // Get the length of the first string as the reference length:
            int referenceLength = matrix.First().Length;

            // Check if matrix exceeds size of 64x64:
            if (referenceLength > 64 || matrix.Count() > 64)
            {
                return false;
            }

            // Check if all strings have the same length:
            return matrix.All(row => row.Length == referenceLength);
        }
    }
}

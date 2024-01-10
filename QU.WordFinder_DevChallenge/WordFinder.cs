using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QU.WordFinder_DevChallenge
{
    public class WordFinder
    {
        private readonly IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            //Check if its a valid matrix:
            if(matrix.IsMatrixValid() != true)
            {
                throw new InvalidMatrixException();
            }

            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            // Horizontal search:
            foreach (string row in _matrix)
            {
                foreach (string word in wordstream.Distinct())
                {
                    if (row.Contains(word))
                    {
                        int count = Regex.Matches(row, word, RegexOptions.IgnoreCase).Count;
                        wordCounts[word] = wordCounts.GetValueOrDefault(word) + count;
                    }
                }
            }

            // Vertical search:
            for (int i = 0; i < _matrix.First().Length; i++)
            {
                StringBuilder column = new StringBuilder();
                foreach (string row in _matrix)
                {
                    column.Append(row[i]);
                }

                foreach (var word in wordstream.Distinct())
                {
                    if (column.ToString().Contains(word))
                    {
                        int count = Regex.Matches(column.ToString(), word, RegexOptions.IgnoreCase).Count;
                        wordCounts[word] = wordCounts.GetValueOrDefault(word) + count;
                    }
                }
            }

            return wordCounts.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;

namespace SharedData.KWIC
{
    public class Alphabetizer
    {
        public List<CharIndex> GetAlphabetizedIndices(char[] input, List<CharIndex> circularlyShifted)
        {
            var comparer = new CharIndexComparer(input);
            var alphabetizedIndices = circularlyShifted.OrderBy(x => x, comparer).ToList();

            return alphabetizedIndices;
        }
    }
}

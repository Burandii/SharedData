using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class Alphabetizer
    {
        public List<CharIndex> GetAlphabetizedIndices(string input, List<CharIndex> circularlyShifted)
        {
            var alphabetizedIndices = new List<CharIndex>();

            int n = circularlyShifted.Count;

            // set up list
            foreach (var index in circularlyShifted)
            {
                alphabetizedIndices.Add(index);
            }

            for (int i = 0; i < n-1; i++)
            {
                
            }

            throw new Exception("Not Implemented");
        }

        private bool AGreaterThanB(CharIndex a, CharIndex b, string input)
        {
            var indexA = a.GetFirst() + a.GetOffset();
            var indexB = b.GetFirst() + b.GetOffset();

            var startingIndexA = indexA;
            var startingIndexB = indexB;

            while (true)
            {
                if (input[indexA] == input[indexB])
                {
                    indexA = GoNextIndex(indexA, a, input);
                    indexB = GoNextIndex(indexB, b, input);
                }
                else
                {
                    return input[indexA] > input[indexB];
                }

                // they are the same words
                if (startingIndexA == indexA && startingIndexB == indexB)
                {
                    break;
                }

            }

            return false;

        }

        private int GoNextIndex(int currentIndex, CharIndex index, string input)
        {
            var nextIndex = currentIndex + 1;

            // if at the end of the line, go to the front
            if (nextIndex >= input.Length || input[nextIndex] == '\r' || input[nextIndex] == '\n')
            {
                currentIndex = index.GetFirst();
            }
            return currentIndex;
        }

        private string GenerateStringLine(CharIndex index, string input)
        {
            var stringBuilder = new StringBuilder();

            var first = index.GetFirst();
            var offset = index.GetOffset();
            var i = first + offset;
            var k = first;

            while (i != input.Length && input[i] != '\r' && input[i] != '\n')
            {
                stringBuilder.Append(input[i]);
                i++;
            }

            if (offset != 0)
            {
                stringBuilder.Append(' ');
            }

            while (k < first + offset - 1)
            {
                stringBuilder.Append(input[k]);
                k++;
            }
            return stringBuilder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class CircularShifter
    {
        public List<CharIndex> GetShiftedWordIndices(char[] input)
        {
            var offsets = new List<CharIndex>();
            var currentOffset = 0;
            var first = 0; // starting index


            // Index starting at 0 instead of 1
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    offsets.Add(new CharIndex(first, currentOffset));
                    // while less than string length and while a non-letter is found
                    while (i < input.Length && (input[i] == '\r' || input[i] == ' ' || input[i] == '\n'))
                    {
                        i++;
                    }

                    currentOffset = i - first;
                }
                // if a new line
                else if (input[i] == '\r' || input[i] == '\n')
                {
                    offsets.Add(new CharIndex(first, currentOffset));
                    while (i < input.Length && (input[i] == '\r' || input[i] == ' ' || input[i] == '\n'))
                    {
                        i++;
                    }

                    first = i;
                    currentOffset = 0;
                }

            }

            // add the very last line
            offsets.Add(new CharIndex(first, currentOffset));

            return offsets;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class CircularShifter
    {
        private readonly string[] _noiseWords =
        {
            "a", "an","the", "and", "or", "of", "to",
            "be", "is", "in", "out", "by", "as",
            "at", "off"
        };

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

            // remove noise words
            var noiseWordIndices = GetNoiseWordIndices(offsets, input);
            offsets = offsets.Except(noiseWordIndices).ToList();

            return offsets;
        }

        private IEnumerable<CharIndex> GetNoiseWordIndices(IEnumerable<CharIndex> circularlyShifted, char[] input)
        {
            var noiseWordLines = new List<CharIndex>();
            foreach (var index in circularlyShifted)
            {
                if (StartsWithNoiseWord(index, input))
                {
                    noiseWordLines.Add(index);
                }
            }

            return noiseWordLines;
        }

        private bool StartsWithNoiseWord(CharIndex index, char[] input)
        {
            var startingIndex = index.GetOffset() + index.GetFirst();
            var firstChar = input[startingIndex];

            if (firstChar == '\t' || firstChar == ' ' || firstChar == '\n')
                return true;
            firstChar = char.ToLowerInvariant(firstChar);

            // noise words only start with these characters
            if (firstChar == 'a' || firstChar == 'i' || firstChar == 'o' || firstChar == 't' || firstChar == 'b')
            {
                var stringBuilder = new StringBuilder();
                int i = startingIndex;
                while (i < input.Length && !(input[i] == '\r' || input[i] == ' ' || input[i] == '\t'))
                {
                    stringBuilder.Append(char.ToLower(input[i]));
                    i++;

                    // too long to be a noise word
                    if (stringBuilder.Length >= 4)
                    {
                        return false;
                    }
                }
                var possibleNoiseWord = stringBuilder.ToString();

                foreach (var noiseWord in _noiseWords)
                {
                    if (possibleNoiseWord == noiseWord)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}

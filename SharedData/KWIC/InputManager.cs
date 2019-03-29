using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class InputManager
    {
        public List<Index> GetFormattedWords(string input)
        {
            var words = new List<Index>();
            // Indexes for words and lines are starting at 0 instead of 1
            var lineNumber = 0;
            var whiteSpaceOrLineBeforeWord = true;
            for (int i = 0; i < input.Length; i++)
            {
                // if a new line
                if (input[i] == '\r' || input[i] == '\n')
                {
                    whiteSpaceOrLineBeforeWord = true;
                    lineNumber++;
                }
                // empty character
                else if (input[i] == ' ')
                {
                    whiteSpaceOrLineBeforeWord = true;
                }
                else
                {
                    // a new word is found
                    if (!whiteSpaceOrLineBeforeWord) continue;
                    words.Add(new Index(lineNumber, i));
                    whiteSpaceOrLineBeforeWord = false;
                }

            }

            return words;
        }

    }
}

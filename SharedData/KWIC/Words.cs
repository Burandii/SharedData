using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class Words
    {
        private readonly List<List<string>> _words;

        public Words(List<List<string>> words)
        {
            _words = words;
        }

        public string GetWord(Index index)
        {
            return _words[index.GetLineNumber()][index.GetWordIndex()];
        }

        public int GetLineCount()
        {
            return _words.Count;
        }

        public int GetWordCountOnLine(int lineNumber)
        {
            return _words[lineNumber].Count;
        }
    }
}

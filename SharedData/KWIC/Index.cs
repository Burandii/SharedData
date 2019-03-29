using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class Index
    {
        private readonly int _line;
        private readonly int _wordIndex;

        public Index(int line, int wordIndex)
        {
            _line = line;
            _wordIndex = wordIndex;
        }

        public int GetLineNumber()
        {
            return _line;
        }

        public int GetWordIndex()
        {
            return _wordIndex;
        }
    }
}

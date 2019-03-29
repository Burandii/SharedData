using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class CharIndex
    {
        private readonly int _first;
        private readonly int _offset;

        public CharIndex(int first, int offset)
        {
            _first = first;
            _offset = offset;
        }

        public int GetFirst()
        {
            return _first;
        }

        public int GetOffset()
        {
            return _offset;
        }
    }
}

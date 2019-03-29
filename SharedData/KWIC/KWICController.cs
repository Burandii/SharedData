using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.KWIC
{
    public class KWICController
    {
        private readonly CircularShifter _circularShifter;
        private readonly Alphabetizer _alphabetizer;
        private OutputManager _outputManager;
        private InputManager _inputManager;

        private string _input;
        private List<CharIndex> _circularShiftIndices;
        private List<CharIndex> _alphabetizedIndices;

        public KWICController()
        {
            _circularShifter = new CircularShifter();
            _alphabetizer = new Alphabetizer();
            _inputManager = new InputManager();
            _outputManager = new OutputManager();
        }

        public void GenerateResult()
        {
            
        }

        public List<string> GetOutput()
        {
            return null;
        }

        public string GenerateSomething()
        {
            var stringBuilder = new StringBuilder();

            foreach (var index in _circularShiftIndices)
            {
                stringBuilder.Append(GenerateStringLine(index, _input));
            }

            return stringBuilder.ToString();
        }

        public List<string> GenerateSomethingList()
        {
            var result = new List<string>();

            foreach (var index in _circularShiftIndices)
            {
                result.Add(GenerateStringLine(index, _input));
            }

            return result;
        }

        public static string GenerateStringLine(CharIndex index, string input)
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

            while (k < first + offset -1)
            {
                stringBuilder.Append(input[k]);
                k++;
            }
            return stringBuilder.ToString();
        }

        public void SetInput(string input)
        {
            _input = input;
            _circularShiftIndices = _circularShifter.GetShiftedWordIndices(input);
        }
    }
}

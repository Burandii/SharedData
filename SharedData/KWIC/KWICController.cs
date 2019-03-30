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
        private readonly OutputManager _outputManager;
        private readonly InputManager _inputManager;

        private char[] _input;
        private List<CharIndex> _circularShiftIndices;
        private List<CharIndex> _alphabetizedIndices;

        public KWICController()
        {
            _circularShifter = new CircularShifter();
            _alphabetizer = new Alphabetizer();
            _inputManager = new InputManager();
            _outputManager = new OutputManager();
        }

        public void SetInput(string input)
        {
            _input = _inputManager.GetFormattedWords(input);
            _outputManager.SetInput(_input);

            GenerateResults();
        }

        private void GenerateResults()
        {
            _circularShiftIndices = _circularShifter.GetShiftedWordIndices(_input);
            _alphabetizedIndices = _alphabetizer.GetAlphabetizedIndices(_input, _circularShiftIndices);
        }

        public string GetAlphabetized()
        {
            return _outputManager.GetStringFromIndices(_alphabetizedIndices);
        }

        public List<string> GetAlphabetizedAsList()
        {
            return _outputManager.GetStringListFromIndices(_alphabetizedIndices);
        }

        public string GetCircularlyShifted()
        {
            return _outputManager.GetStringFromIndices(_circularShiftIndices);
        }

        public List<string> GetCircularlyShiftedAsList()
        {
            return _outputManager.GetStringListFromIndices(_circularShiftIndices);
        }

    }
}

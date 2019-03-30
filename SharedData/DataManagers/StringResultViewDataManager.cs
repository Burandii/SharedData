using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedData.KWIC;
using SharedData.Models;

namespace SharedData.DataManagers
{
    public class StringResultViewDataManager
    {
        private readonly KWICController _sharedData;
        private readonly string _input;
        public StringResultViewDataManager(string input)
        {
            _sharedData = new KWICController();
            _input = input;
        }

        public StringResultViewModel GetStringResultViewModel()
        {
            _sharedData.SetInput(_input);

            var viewModel = new StringResultViewModel
            {
                Alphabetized = _sharedData.GetAlphabetizedAsList(),
                CircularlyShifted = _sharedData.GetCircularlyShiftedAsList(),
                UserInput = _input
            };

            return viewModel;
        }
    }
}

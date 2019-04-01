using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class StringResultViewModel
    {
        public long ElapsedTimeMs { get; set; }
        public string UserInput { get; set; }
        public List<string> Alphabetized { get; set; }
        public List<string> CircularlyShifted { get; set; }
    }
}

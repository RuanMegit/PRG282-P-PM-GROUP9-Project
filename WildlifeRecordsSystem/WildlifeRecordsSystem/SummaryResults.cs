using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeRecordsSystem
{
    class SummaryResults
    {
        public int TotalAnimals { get; set; }
        public double AverageAge { get; set; }
        public double AverageScore { get; set; } 
        public int CriticalCount { get; set; }
        public int SeriousCount { get; set; }
        public int StableCount { get; set; }
        public int RecoveringCount { get; set; }
        public int ReleaseReadyCount { get; set; }
    }
}

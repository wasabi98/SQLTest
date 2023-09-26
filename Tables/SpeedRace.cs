using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class SpeedRace
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public int SafetyCarFollowed { get; set; }
        public int SafetyCarOvertaken { get; set; }
        public int BestLapTime { get; set; }
        public int IsAborted { get; set; }
        public int TouchCount { get; set; }
        public int AdditionalPoints { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class SkillRace
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public int StartSucceded { get; set; }
        public int LaneChangeSucceeded { get; set; }
        public int CheckpointState { get; set; }
        public int Time { get; set; }
        public int Points { get; set; }
        public int isAborted { get; set; }
        //public int TouchCount { get; set; }
    }
}

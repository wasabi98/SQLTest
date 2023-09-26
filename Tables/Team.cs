using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class Team
    {
        

        public int TeamID { get; set; }
        public string? Name { get; set; }
        public int IsJunior { get; set; }
        public int QualificationPoint { get; set; }
        public int AudienceVoteCount { get; set; }
    }
}

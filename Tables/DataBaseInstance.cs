using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class DataBaseInstance
    {
        public List<Lap>        laps        = new List<Lap>();
        public List<SkillRace>  skillRaces  = new List<SkillRace>();
        public List<SpeedRace>  speedRaces  = new List<SpeedRace>();
        public List<Team>       teams       = new List<Team>();
        public List<TeamMember> teamMembers = new List<TeamMember>();
    }
}

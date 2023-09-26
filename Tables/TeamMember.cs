using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class TeamMember
    {
        

        public int ID { get; set; }
        public int TeamID { get; set; }
        public string? Name { get ; set ; }
    }
}

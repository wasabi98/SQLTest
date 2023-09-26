using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTest.Tables
{
    internal class Lap
    {
       public int ID { get; set;}
       public int SpeedRaceID { get; set;}
       public int LaserTime { get; set;}
       public int ManualTime { get; set;}
       public int SelectedTime { get; set;}
       public int IsWarmUp { get; set;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombSquad.Models
{
    public class Move
    {
        public Move(
           String name,
           String english,
           Int32 level)
        {
            Name = name;
            English = english;
            Level = level;
        }
        public String Name { get; set; }
        public String English { get; set; }
        public Int32 Level { get; set; }
    }
}

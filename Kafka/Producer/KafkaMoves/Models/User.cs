using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombSquad.Models
{
    public class User
    {
        public User(
            String name,
            String level,
            String weapon)
        {
            Name = name;
            Level = level;
            Weapon = weapon;
        }
        public String Name { get; set; }
        public String Level { get; set; }
        public String Weapon { get; set; }
    }
}

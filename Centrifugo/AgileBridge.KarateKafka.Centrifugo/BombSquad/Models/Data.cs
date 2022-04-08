using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombSquad.Models
{
    public class Data
    {
        public Data(
            List<User> users,
            List<Move> moves
            )
        {
            Users = users;
            Moves = moves;
        }
        public List<User> Users { get; set; }
        public List<Move> Moves { get; set; }
    }
}

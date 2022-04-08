using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombSquad.Models
{
    public class UserMove
    {
        public UserMove(User user, Move move)
        {
            User = user;
            Move = move;
        }

        public User? User { get; set; }
        public Move? Move { get; set; }
    }
}

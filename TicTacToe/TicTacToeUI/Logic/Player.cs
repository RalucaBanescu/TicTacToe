using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeUI.Logic
{
   public class Player
    {
        private string sign;
        public string Name { get; set; }

        public Player(string name, string sign) {
            this.Name = name;
            this.sign = sign;
        }
    }
}

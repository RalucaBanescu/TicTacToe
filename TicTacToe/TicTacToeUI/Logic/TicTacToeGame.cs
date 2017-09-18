using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeUI.Logic
{
    public class TicTacToeGame
    {
        private Cell[,] board;
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        // Un fel de metoda care nu are tip returnat si are numele clasei(Constrctor)
        public TicTacToeGame(string firstPlayerName, string secondPlayerName)
        {
            this.board = new Cell[3, 3];
            FirstPlayer = new Player(firstPlayerName, "X");
            SecondPlayer = new Player(secondPlayerName, "O");
        }


    }
}

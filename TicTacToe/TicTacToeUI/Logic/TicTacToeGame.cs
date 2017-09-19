using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToeUI.Logic
{
    public class TicTacToeGame: DependencyObject

    {
        public Cell[,] Board { get; set; }
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public static int BoardSize = 3;


        public Player ActivePlayer
        {
            get { return (Player)GetValue(ActivePlayerProperty); }
            set { SetValue(ActivePlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActivePlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActivePlayerProperty =
            DependencyProperty.Register("ActivePlayer", typeof(Player), typeof(TicTacToeGame));


        //public  Player ActivePlayer { get; set; }

        // Un fel de metoda care nu are tip returnat si are numele clasei(Constrctor)
        public TicTacToeGame(string firstPlayerName, string secondPlayerName)
        {
            this.Board = new Cell[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    this.Board[i, j] = new Cell();
                }
            }

            FirstPlayer = new Player(firstPlayerName, "X");
            SecondPlayer = new Player(secondPlayerName, "O");
            ActivePlayer = FirstPlayer;

        }

        internal void MarkCellWithActivePlayer(Cell cell)
        {
            cell.ActivePlayer = this.ActivePlayer;
           if( ActivePlayer!= FirstPlayer)
            {
                ActivePlayer = FirstPlayer;
            }
           else
            {
                ActivePlayer = SecondPlayer;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToeUI.Logic
{
    public enum GameResult
    {
        Tie,
        Win,
        InProgress
    }

    public delegate void GameEndedWithResult(GameResult result);

    public class TicTacToeGame : DependencyObject
    {
        public Cell[,] Board { get; set; }
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public static int BoardSize = 3;

        public event GameEndedWithResult GameEndedWithResultEvent;

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
            GameResult result = GameEnded();
            if (result == GameResult.InProgress)
            {
                if (ActivePlayer != FirstPlayer)
                {
                    ActivePlayer = FirstPlayer;
                }
                else
                {
                    ActivePlayer = SecondPlayer;
                }
            }
            else
            {
                // mesaj
                GameEndedWithResultEvent(result);
            }
        }

        private GameResult GameEnded()
        {
            for (int i = 0; i < BoardSize; i++)

            {
                if (Board[i, 0].ActivePlayer == Board[i, 1].ActivePlayer 
                    && Board[i, 1].ActivePlayer == Board[i, 2].ActivePlayer 
                    && Board[i, 0].ActivePlayer != null)
                {
                    return GameResult.Win;
                }

            }
            return GameResult.InProgress;
            /*
                        for (int j = 0; j < BoardSize; j++)
                        {
                            if (Board[j, j] == Board[j + 1, j] && Board[j + 1, j] == Board[j + 2, j] && Board[j, j] != null)
                                return true;
                        }


                        for (int i = 0; i < BoardSize; i++)
                        {
                            if (Board[i, i] == Board[i + 1, i + 1] && Board[i + 1, i + 1] == Board[i + 2, i + 2] && Board[i + 1, i + 1] != null)
                            {
                                return true;
                            }
                        }
                        if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 0] && Board[0, 2] != null)
                        {
                            return true;
                        }
                        */
        }
    }
}

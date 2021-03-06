﻿using System;
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

        internal void Reset()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Board[i, j].ActivePlayer = null;
                }
            }
        }

        internal void MarkCellWithActivePlayer(Cell cell)
        {   
            if (cell.ActivePlayer == null)
            { // mark cell
                cell.ActivePlayer = this.ActivePlayer;

                // test if game ended
                GameResult result = GameEnded();
                

                // switch players if game not ended
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
                    if (result == GameResult.Win)
                    {
                        ActivePlayer.TimesWon++;
                    }

                    
                    // if game ended, notify UI to show message
                    GameEndedWithResultEvent(result);
                }
            }
        }

        private GameResult GameEnded()
        {
            #region Check rows
            for (int row = 0; row < BoardSize; row++)
            {
                bool isRowOccupiedBySamePlayer = true;
                for (int col = 0; col < BoardSize - 1; col++)
                {
                    if (Board[row, col].ActivePlayer != Board[row, col + 1].ActivePlayer)
                    {
                        isRowOccupiedBySamePlayer = false;
                    }
                }

                if (isRowOccupiedBySamePlayer && Board[row, 0].ActivePlayer != null)
                {
                    return GameResult.Win;
                }
            }
            #endregion

            #region Check columns
            for (int col = 0; col < BoardSize; col++)
            {
                bool isColOccupiedBySamePlayer = true;
                for (int row = 0; row < BoardSize - 1; row++)
                {
                    if (Board[row, col].ActivePlayer != Board[row + 1, col].ActivePlayer)
                    {
                        isColOccupiedBySamePlayer = false;
                    }
                }
                if (isColOccupiedBySamePlayer && Board[0, col].ActivePlayer != null)
                {
                    return GameResult.Win;
                }
            }
            #endregion

            #region Check primary diagonal 
            bool isPrimaryDiagonalOccupiedBySamePlayer = true;
            for (int i = 0; i < BoardSize - 1; i++)
            {
                if (Board[i, i].ActivePlayer != Board[i + 1, i + 1].ActivePlayer)
                {
                    isPrimaryDiagonalOccupiedBySamePlayer = false;
                }
            }
            if (isPrimaryDiagonalOccupiedBySamePlayer && Board[0, 0].ActivePlayer != null)
            {
                return GameResult.Win;
            }
            #endregion

            #region Check Second diagonal
            bool isSecondDiagonalOccupiedBySamePlayer = true;
            for (int i = 0; i < BoardSize - 1; i++)
            {
                if (Board[i, BoardSize - 1 - i].ActivePlayer != Board[i + 1, BoardSize - 2 - i].ActivePlayer)
                {
                    isSecondDiagonalOccupiedBySamePlayer = false;
                }
            }
            if (isSecondDiagonalOccupiedBySamePlayer && Board[0, BoardSize - 1].ActivePlayer != null)
            {
                return GameResult.Win;
            }
           #endregion

            bool allCellsAreOccupied = true;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Board[i, j].ActivePlayer == null)
                    {
                        allCellsAreOccupied = false;
                    }
                }
            }

            if (allCellsAreOccupied)
            {
                return GameResult.Tie;

            }

            return GameResult.InProgress;
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeUI.Logic;

namespace TicTacToeUI.UserControls
{
    /// <summary>
    /// Interaction logic for GameUserControl.xaml
    /// </summary>
    public partial class GameUserControl : UserControl
    {
        public TicTacToeGame Game { get; set; }

        public GameUserControl(string firstPlayerName, string secondPlayerName)
        {
            InitializeComponent();
            this.Game = new TicTacToeGame(firstPlayerName, secondPlayerName);
            this.DataContext = this.Game;

            for (int i = 0; i < TicTacToeGame.BoardSize; i++)
            {
                for (int j = 0; j < TicTacToeGame.BoardSize; j++)
                {
                    listBoxCells.Items.Add(this.Game.Board[i, j]);
                }
            }
            //abonare la event
            Game.GameEndedWithResultEvent += Game_GameEndedWithResultEvent;
        }

        //event handler
        private void Game_GameEndedWithResultEvent(GameResult result)
        {
            if (result == GameResult.Win)
            {
                MessageBox.Show("Joc castigat de: " + this.Game.ActivePlayer.Name);
            }
            if (result ==GameResult.Tie)
            {
                MessageBox.Show("Joc finalizat cu egalitate");
            }
            this.Game.Reset();
        }

        private void cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CellUserControl cellUC = sender as CellUserControl;
            if (cellUC != null)
            {
                Cell cell = cellUC.DataContext as Cell;
                if (cell != null)
                {
                    this.Game.MarkCellWithActivePlayer(cell);
                }
            }

        }
    }
}

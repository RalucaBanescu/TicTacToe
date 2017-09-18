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
        }

    }
}

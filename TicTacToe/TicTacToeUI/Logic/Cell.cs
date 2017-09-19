using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToeUI.Logic
{
    public class Cell: DependencyObject
    {




        public Player ActivePlayer
        {
            get { return (Player)GetValue(ActivePlayerProperty); }
            set { SetValue(ActivePlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActivePlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActivePlayerProperty =
            DependencyProperty.Register("ActivePlayer", typeof(Player), typeof(Cell));



    
    }
}

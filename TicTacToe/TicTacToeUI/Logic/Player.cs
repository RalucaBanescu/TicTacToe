using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToeUI.Logic
{
    public class Player : DependencyObject
    {
        public string Sign
        {
            get { return (string)GetValue(SignProperty); }
            set { SetValue(SignProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sign.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignProperty =
            DependencyProperty.Register("Sign", typeof(string), typeof(Player));



        public string Name { get; set; }

        public Player(string name, string sign)
        {
            this.Name = name;
            this.Sign = sign;
        }
    }
}

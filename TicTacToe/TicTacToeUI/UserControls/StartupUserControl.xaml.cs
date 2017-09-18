using System;
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

namespace TicTacToeUI.UserControls
{
    /// <summary>
    /// Interaction logic for StartupUserControl.xaml
    /// </summary>
    public partial class StartupUserControl : UserControl
    {
        public StartupUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstPlayerName = txtFirstPlayer.Text;
            string secoundPlayerName = txtSecoundPlayer.Text;
            if (string.IsNullOrEmpty(firstPlayerName) || string.IsNullOrWhiteSpace(firstPlayerName))
            {
                MessageBox.Show("Nu ati introdus numele primului jucator");
                return;
            }
            if (string.IsNullOrEmpty(secoundPlayerName) || string.IsNullOrWhiteSpace(secoundPlayerName))
            {
                MessageBox.Show("Nu ati introdus numele celui de-al doilea jucator");
                return;
            }

            (App.Current.MainWindow as MainWindow).ShowGameScreen(firstPlayerName, secoundPlayerName);
             
         

        }
    }
}

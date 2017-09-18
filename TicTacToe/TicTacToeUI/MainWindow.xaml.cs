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
using TicTacToeUI.UserControls;

namespace TicTacToeUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowStartupScreen();
        }

        public void ShowStartupScreen()
        {
            StartupUserControl startupUC = new StartupUserControl();
            this.Content = startupUC;
        }

        public void ShowGameScreen(string firstPlayerName, string secondPlayerName)
        {
            GameUserControl gameUC = new GameUserControl(firstPlayerName, secondPlayerName);
            this.Content = gameUC;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

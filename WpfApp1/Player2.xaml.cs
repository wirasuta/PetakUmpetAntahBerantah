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
using System.IO;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Player2.xaml
    /// </summary>
    public partial class Player2 : Page
    {
        public Player2()
        {
            InitializeComponent();
        }

        private void inputQuery(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("C:\\Users\\x550\\source\\repos\\WpfApp1\\WpfApp1\\queryInput.txt", queryInput.Text);
            ShowGraph s = new ShowGraph();
            ((MainWindow)Application.Current.MainWindow).Content = s;
        }

        private void bactToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption ch = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = ch;
        }

        private void backToInputGraph(object sender, RoutedEventArgs e)
        {
            Player p = new Player();
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }
    }
}

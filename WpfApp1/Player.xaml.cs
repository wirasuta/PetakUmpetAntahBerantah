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
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : Page
    {
        public Player()
        {
            InitializeComponent();
        }

    /*    private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        } */

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void inputGraph(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("C:\\Users\\x550\\source\\repos\\WpfApp1\\WpfApp1\\graphInput.txt", graphInput.Text);
            Player2 p = new Player2();
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        private void backToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption ch = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = ch;
        }
    }
}

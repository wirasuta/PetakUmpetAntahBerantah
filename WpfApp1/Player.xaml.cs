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


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void inputGraph(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("D:\\Documents\\GitHub\\PetakUmpetAntahBerantah\\WpfApp1\\bin\\Debug\\graphInput.txt", graphInput.Text);
            string passingGraph = "graphInput.txt";
            Player2 p = new Player2(passingGraph);
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        private void backToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption ch = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = ch;
        }

        private void GraphChoose_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void inputExistingGraph(object sender, RoutedEventArgs e)
        {
            string passingGraph = graphChoose.Text;
            Player2 p = new Player2(passingGraph);
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        private void browseExistingGraph(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog di = new Microsoft.Win32.OpenFileDialog();
            di.DefaultExt = ".txt";
            Nullable<bool> result = di.ShowDialog();

            if (result == true)
            {
                string fileName = di.FileName;
                graphChoose.Text = fileName;
            }
        }
    }
}

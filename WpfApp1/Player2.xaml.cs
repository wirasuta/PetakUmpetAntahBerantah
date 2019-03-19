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
        public string receivedGraph;
        public Player2(string name)
        {
            receivedGraph = name;
            InitializeComponent();
            showSelectedGraph();
        }

        private void inputQuery(object sender, RoutedEventArgs e)
        {
            string passingQuery = "queryInput.txt";
            File.WriteAllText("D:\\Documents\\GitHub\\PetakUmpetAntahBerantah\\WpfApp1\\bin\\Debug\\queryInput.txt", queryInput.Text);
            PlayerGraph g = new PlayerGraph(receivedGraph, passingQuery);
            ((MainWindow)Application.Current.MainWindow).Content = g;
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

        private void showSelectedGraph()
        {

            TextBlock selectedGraph = new TextBlock();
            selectedGraph.Height = 50;
            selectedGraph.Width = 200;
            selectedGraph.Text = "Showing Graph: " + receivedGraph;
            selectedGraph.FontSize = 9;
            Canvas.SetLeft(selectedGraph, 10);
            Canvas.SetTop(selectedGraph, 10);
            selectedGraph.Foreground = new SolidColorBrush(Colors.Red);
            P_QueryCanvas.Children.Add(selectedGraph);
        }

        private void inputExistingQuery(object sender, RoutedEventArgs e)
        {
            string passingQuery = queryChoose.Text;
            PlayerGraph g = new PlayerGraph(receivedGraph, passingQuery);
            ((MainWindow)Application.Current.MainWindow).Content = g;
        }

        private void browseExistingQuery(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog di = new Microsoft.Win32.OpenFileDialog();
            di.DefaultExt = ".txt";
            Nullable<bool> result = di.ShowDialog();

            if (result == true)
            {
                string fileName = di.FileName;
                queryChoose.Text = fileName;
            }
        }
    }
}

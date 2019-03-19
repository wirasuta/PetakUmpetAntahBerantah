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
        //atrribut yang digunakan sebagai passing parameter ke page selanjutnya
        public string receivedGraph;

        //Ctor page Player2
        public Player2(string name)
        {
            receivedGraph = name;
            InitializeComponent();

            //Menampilkan nama graf yang dipilih pada pojok kiri atas
            showSelectedGraph();
        }

        //Menyimpan value yang berada dalam textbox queryInput ke dalam file external
        private void inputQuery(object sender, RoutedEventArgs e)
        {
            //Lokasi penyimpanan file graf: D:\Documents\GitHub\PetakUmpetAntahBerantah\WpfApp1\bin\Debug
            File.WriteAllText("D:\\Desktop\\queryInput.txt", queryInput.Text);
            string passingQuery = "D:\\Desktop\\queryInput.txt";

            //Membuat objek page PlayerGraph
            PlayerGraph g = new PlayerGraph(receivedGraph, passingQuery);
            //Berpindah ke page PlayerGraph
            ((MainWindow)Application.Current.MainWindow).Content = g;
        }

        //Kembali ke page ChooseOption
        private void bactToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption ch = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = ch;
        }

        //Kembali ke page Player
        private void backToInputGraph(object sender, RoutedEventArgs e)
        {
            Player p = new Player();
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        //Menampilkan nama/lokasi graf yang dipilih
        private void showSelectedGraph()
        {
            //Membuat objek textbox untuk menampilkan nama/lokasi graf
            TextBlock selectedGraph = new TextBlock();
            selectedGraph.Height = 50;
            selectedGraph.Width = 200;
            selectedGraph.Text = "Showing Graph: " + receivedGraph;
            selectedGraph.FontSize = 9;
            Canvas.SetLeft(selectedGraph, 10);
            Canvas.SetTop(selectedGraph, 10);
            selectedGraph.Foreground = new SolidColorBrush(Colors.Yellow);

            //Menambahkan textbox selectedGraph ke canvas
            P_QueryCanvas.Children.Add(selectedGraph);
        }

        //Menyimpan value yang berada pada textbox queryChoose yang berupa nama file query
        private void inputExistingQuery(object sender, RoutedEventArgs e)
        {
            string passingQuery = queryChoose.Text;
            PlayerGraph g = new PlayerGraph(receivedGraph, passingQuery);
            ((MainWindow)Application.Current.MainWindow).Content = g;
        }

        //Membuka dialog open file ketika button BROWSE diklik
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

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
        //Constructor for Player page
        public Player()
        {
            InitializeComponent();
        }

        //Menyimpan value yang berada dalam textbox graphInput ke dalam file external
        private void inputGraph(object sender, RoutedEventArgs e)
        {
            //Lokasi penyimpanan file graf: D:\Documents\GitHub\PetakUmpetAntahBerantah\WpfApp1\bin\Debug
            File.WriteAllText("D:\\Desktop\\graphInput.txt", graphInput.Text);
            string passingGraph = "D:\\Desktop\\graphInput.txt";
            Player2 p = new Player2(passingGraph);
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        //Kembali ke main menu (dimana pengguna memilih antara Watcher atau Player
        private void backToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption ch = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = ch;
        }

        //Menyimpan value yang berada pada textbox graphChoose yang berupa nama file graf
        private void inputExistingGraph(object sender, RoutedEventArgs e)
        {
            string passingGraph = graphChoose.Text;
            Player2 p = new Player2(passingGraph);
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        //Membuka dialog open file ketika button BROWSE diklik
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

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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Watcher.xaml
    /// </summary>
    public partial class Watcher : Page
    {
        //Ctor untuk page Watcher
        public Watcher()
        {
            InitializeComponent();
        }

        //Kembali ke page ChooseOption
        private void BackToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption choose1 = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = choose1;
        }

        //Browse file graf
        private void selectFile(object sender, RoutedEventArgs e)
        {
            //Membuat dan membuka open file dialog
            Microsoft.Win32.OpenFileDialog di = new Microsoft.Win32.OpenFileDialog();
            di.DefaultExt = ".txt";
            Nullable<bool> result = di.ShowDialog();

            if(result == true)
            {
                string fileName = di.FileName;
                graphName.Text = fileName;
            }

        }


        private void W_ShowGraph(object sender, RoutedEventArgs e)
        {
            string gName = graphName.Text;
            WatcherGraph w1 = new WatcherGraph(gName);

            ((MainWindow)Application.Current.MainWindow).Content = w1;

        }

        private void toMainMenu(object sender, RoutedEventArgs e)
        {
            ChooseOption c = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = c;
        }
    }
}

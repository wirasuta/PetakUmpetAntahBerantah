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
    /// Interaction logic for ChooseOption.xaml
    /// </summary>
    public partial class ChooseOption : Page
    {
        public ChooseOption()
        {
            InitializeComponent();
        }

        private void AWatcher(object sender, RoutedEventArgs e)
        {
            Watcher w = new Watcher();
            ((MainWindow)Application.Current.MainWindow).Content = w;
        }
        private void APlayer(object sender, RoutedEventArgs e)
        {
            Player p = new Player();
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }
    }
}

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
//using System.Windows.Forms;
//using System.Drawing;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Watcher.xaml
    /// </summary>
    public partial class Watcher : Page
    {
        public Watcher()
        {
            InitializeComponent();
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            ChooseOption choose1 = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = choose1;
        }

        private void selectFile(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;

        }

        private void DisplayPopup(object sender, RoutedEventArgs e)
        {
            //myPopup.IsOpen = true;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // YesButton Clicked! Let's hide our InputBox and handle the input text.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Do something with the Input
            String input = InputTextBox.Text;
            graphName.Clear();
            graphName.AppendText(input);
            graphName.Foreground = Brushes.Red;

            //InputTextBox.Text = String.Empty;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // NoButton Clicked! Let's hide our InputBox.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }

        private void W_ShowGraph(object sender, RoutedEventArgs e)
        {
            string gName = graphName.Text;
            WatcherGraph w1 = new WatcherGraph(gName);

            ((MainWindow)Application.Current.MainWindow).Content = w1;

        }
    }
}

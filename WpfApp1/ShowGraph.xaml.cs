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
    /// Interaction logic for ShowGraph.xaml
    /// </summary>
    public partial class ShowGraph : Page
    {
        public ShowGraph()
        {
            InitializeComponent();
            drawGraph();
        }

        private void drawGraph()
        {
            for (int i = 1; i <= 10; i++)
            {
                Ellipse graphNode = new Ellipse();
                graphNode.Stroke = System.Windows.Media.Brushes.Black;
                graphNode.Fill = System.Windows.Media.Brushes.Red;
                graphNode.Width = 30;
                graphNode.Height = 30;

                Canvas.SetLeft(graphNode, (i % 5 * 50) + 400);
                if (i <= 5)
                {
                    Canvas.SetTop(graphNode, 10);
                }
                else
                {
                    Canvas.SetTop(graphNode, 60);
                }

                G_Canvas.Children.Add(graphNode);
            }
        }
    }
}

using PetakUmpetAntahBerantah;
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
using System.Timers;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WatcherGraph.xaml
    /// </summary>
    public partial class WatcherGraph : Page
    {
        public string graphFile;
        public string queryFile;
        public Graph watcherGraph;
        public List<int>[] watcherQuery;
        public int nQuery;
        public int nNode;
        public int time;

        private DispatcherTimer timer;

        public WatcherGraph(string name)
        {
            graphFile = name;
            InitializeComponent();
            ShowTitle();
            ShowDFS();
        }

        private void ShowTitle()
        {
            //INFORMATION OF THE GRAPH
            TextBlock gFile = new TextBlock();
            gFile.Height = 50;
            gFile.Width = 200;
            gFile.Text = "Showing Graph: " + graphFile;
            gFile.FontSize = 9;
            gFile.VerticalAlignment = VerticalAlignment.Top;
            gFile.HorizontalAlignment = HorizontalAlignment.Center;
            Canvas.SetLeft(gFile, 10);
            Canvas.SetTop(gFile, 10);
            gFile.Foreground = new SolidColorBrush(Colors.Red);
            W_Canvas.Children.Add(gFile);


            Graph G1 = new Graph(graphFile);
            Solver.setDatangPergiY(G1);
            Solver.setAllX(G1);

            TextBlock nNode = new TextBlock();
            nNode.Height = 50;
            nNode.Width = 200;
            nNode.Text = "Total of Node " + G1.getNodeCount();
            nNode.FontSize = 9;
            nNode.VerticalAlignment = VerticalAlignment.Top;
            nNode.HorizontalAlignment = HorizontalAlignment.Center;
            Canvas.SetLeft(nNode, 10);
            Canvas.SetTop(nNode, 20);
            nNode.Foreground = new SolidColorBrush(Colors.Red);
            W_Canvas.Children.Add(nNode);

            for (int i = 1; i <= G1.getNodeCount(); i++)
            {
                Ellipse graphNode = new Ellipse();
                graphNode.Name = "node" + i;
                graphNode.Stroke = System.Windows.Media.Brushes.Black;
                graphNode.Fill = System.Windows.Media.Brushes.LightGray;
                graphNode.Width = 30;
                graphNode.Height = 30;

                Canvas.SetLeft(graphNode, G1.getNode(i).getX()*5);
                Canvas.SetTop(graphNode, G1.getNode(i).getY()*5);


                TextBlock nodeID = new TextBlock();
                nodeID.Height = 50;
                nodeID.Width = 200;
                nodeID.Text = i.ToString();
                nodeID.FontSize = 12;
                
                Canvas.SetLeft(nodeID, G1.getNode(i).getX() * 5 + 8);
                Canvas.SetTop(nodeID, G1.getNode(i).getY() * 5);
                nNode.Foreground = new SolidColorBrush(Colors.Black);

                

                if (G1.getNode(i).getNeighbours().Count != 0)
                {
                    List<int> nodeNeighbor = G1.getNode(i).getNeighbours();

                    for (int j = 0; j < nodeNeighbor.Count; j++)
                    {
                        Line connector = new Line();
                        connector.Stroke = System.Windows.Media.Brushes.Black;
                        connector.X1 = G1.getNode(i).getX()*5 + 15;
                        connector.X2 = G1.getNode(nodeNeighbor[j]).getX()*5 + 15;
                        connector.Y1 = G1.getNode(i).getY()*5 + 15;
                        connector.Y2 = G1.getNode(nodeNeighbor[j]).getY()*5 + 15;
                        connector.HorizontalAlignment = HorizontalAlignment.Center;
                        connector.VerticalAlignment = VerticalAlignment.Center;
                        connector.StrokeThickness = 1;
                       
                        W_Canvas.Children.Add(connector);
                    }
                    
                }
                W_Canvas.Children.Add(graphNode);
                Canvas.SetZIndex(graphNode, 1);
                W_Canvas.Children.Add(nodeID);
                Canvas.SetZIndex(nodeID, 2);
            }
            watcherGraph = G1;
        }

        private void ShowDFS()
        {
            time = 1;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.IsEnabled = true;
            timer.Tick += DFSDatangPergi;
        }

        private void DFSDatangPergi(object sender, EventArgs e)
        {
            if (time > 2 * watcherGraph.getNodeCount())
            {
                timer.Stop();
                queryBox.IsEnabled = true;
                startQuery.IsEnabled = true;
                browseQuery.IsEnabled = true;
                timer.Tick -= DFSDatangPergi;
            }
            else
            {
                int idNode = watcherGraph.getNodeIdByDatang(time);
                Brush newFill;
                if (idNode != 0)
                {
                    newFill = System.Windows.Media.Brushes.Blue;
                }
                else
                {
                    idNode = watcherGraph.getNodeIdByPergi(time);
                    newFill = System.Windows.Media.Brushes.Red;
                }
                string nodeName = "node" + idNode;
                foreach (Ellipse el in W_Canvas.Children.OfType<Ellipse>())
                {
                    if (el.Name == nodeName)
                    {
                        el.Fill = newFill;
                    }

                }
                time++;
            }
        }

        private void querySolution(object sender, RoutedEventArgs e)
        {
            queryFile = queryBox.Text;

            watcherQuery = Solver.solveFile(watcherGraph, queryFile);
            nQuery = 0;
            nNode = 0;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Start();
            timer.Tick += traverseSolution;
        }

        void traverseSolution(object sender, EventArgs e)
        {
            TextBlock status = new TextBlock();
            status.Height = 18;
            status.Width = 213;
            status.FontSize = 10;
            Canvas.SetLeft(status, 300);
            Canvas.SetTop(status, 30);
            status.Foreground = new SolidColorBrush(Colors.LightGray);
            W_Canvas.Children.Add(status);

            if (nQuery == watcherQuery.Length)
            {
                timer.Stop();
                timer.Tick -= traverseSolution;
            }
            else
            {
                
                if (nNode == 0)
                {
                    foreach (Ellipse el in W_Canvas.Children.OfType<Ellipse>())
                    {
                        el.Fill = System.Windows.Media.Brushes.Red;
                    }
                }
                if (watcherQuery[nQuery].Count != 0)
                {
                   
                    int queryLine = nQuery + 1;
                    status.Text = "  STATUS: YES FOR QUERY #" + queryLine;
                    status.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE6E6E6"));
                    status.Foreground = new SolidColorBrush(Colors.Green);
                    foreach (Ellipse el in W_Canvas.Children.OfType<Ellipse>())
                    {
                        string nodeName = "node" + watcherQuery[nQuery].ToArray()[nNode];
                        if (el.Name == nodeName)
                        {
                            el.Fill = System.Windows.Media.Brushes.Green;
                        }

                    }
                    nNode++;
                    if (nNode == watcherQuery[nQuery].Count)
                    {
                        nNode = 0;
                        nQuery++;
                    }
                    //status.Text = String.Empty;

                }
                else
                {
                    int queryLine = nQuery + 1;
                    status.Text = "  STATUS: NO FOR QUERY #" + queryLine;
                    status.Foreground = new SolidColorBrush(Colors.DarkRed);
                    status.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE6E6E6"));
                    nQuery++;
                }
                
            }

        }

        private void backTo(object sender, RoutedEventArgs e)
        {
            Watcher p = new Watcher();
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        private void backToMainMenu(object sender, RoutedEventArgs e)
        {
            ChooseOption c = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = c;
        }

        private void browse(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog di = new Microsoft.Win32.OpenFileDialog();
            di.DefaultExt = ".txt";
            Nullable<bool> result = di.ShowDialog();

            if (result == true)
            {
                string fileName = di.FileName;
                queryBox.Text = fileName;
            }
        }
    }
}

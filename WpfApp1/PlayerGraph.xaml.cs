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
    /// Interaction logic for PlayerGraph.xaml
    /// </summary>
    public partial class PlayerGraph : Page
    {
        public string graphFilePlayer;
        public string queryFilePlayer;
        public Graph playerGraph;
        public List<int>[] playerQuery;
        public int nQueryPlayer;
        public int nNodePlayer;
        public int time;
        private DispatcherTimer timer;

        public PlayerGraph(string graph, string query)
        {
            graphFilePlayer = graph;
            queryFilePlayer = query;
            InitializeComponent();
            showTitle();
            drawGraph();
            ShowDFS();
            //startQuery.IsEnabled = true;
        }

        private void showTitle()
        {
            TextBlock selectedGraph = new TextBlock();
            selectedGraph.Height = 50;
            selectedGraph.Width = 200;
            selectedGraph.Text = "Showing Graph: " + graphFilePlayer;
            selectedGraph.FontSize = 9;
            Canvas.SetLeft(selectedGraph, 10);
            Canvas.SetTop(selectedGraph, 10);
            selectedGraph.Foreground = new SolidColorBrush(Colors.Red);
            P_Canvas.Children.Add(selectedGraph);

            TextBlock selectedQuery = new TextBlock();
            selectedQuery.Height = 50;
            selectedQuery.Width = 200;
            selectedQuery.Text = "Showing Query: " + queryFilePlayer;
            selectedQuery.FontSize = 9;
            Canvas.SetLeft(selectedQuery, 10);
            Canvas.SetTop(selectedQuery, 20);
            selectedQuery.Foreground = new SolidColorBrush(Colors.Red);
            P_Canvas.Children.Add(selectedQuery);
        }

        private void drawGraph()
        {
            Graph G1 = new Graph(graphFilePlayer);
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
            Canvas.SetTop(nNode, 30);
            nNode.Foreground = new SolidColorBrush(Colors.Red);
            P_Canvas.Children.Add(nNode);

            for (int i = 1; i <= G1.getNodeCount(); i++)
            {
                Ellipse graphNode = new Ellipse();
                graphNode.Name = "node" + i;
                graphNode.Stroke = System.Windows.Media.Brushes.Black;
                graphNode.Fill = System.Windows.Media.Brushes.LightGray;
                graphNode.Width = 30;
                graphNode.Height = 30;

                Canvas.SetLeft(graphNode, G1.getNode(i).getX() * 5);
                Canvas.SetTop(graphNode, G1.getNode(i).getY() * 5);


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
                        connector.X1 = G1.getNode(i).getX() * 5 + 15;
                        connector.X2 = G1.getNode(nodeNeighbor[j]).getX() * 5 + 15;
                        connector.Y1 = G1.getNode(i).getY() * 5 + 15;
                        connector.Y2 = G1.getNode(nodeNeighbor[j]).getY() * 5 + 15;
                        connector.HorizontalAlignment = HorizontalAlignment.Center;
                        connector.VerticalAlignment = VerticalAlignment.Center;
                        connector.StrokeThickness = 1;

                        P_Canvas.Children.Add(connector);
                    }

                }
                P_Canvas.Children.Add(graphNode);
                Canvas.SetZIndex(graphNode, 1);
                P_Canvas.Children.Add(nodeID);
                Canvas.SetZIndex(nodeID, 2);
            }
            playerGraph = G1;

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
            if (time > 2 * playerGraph.getNodeCount())
            {
                timer.Stop();
                startQuery.IsEnabled = true;
                timer.Tick -= DFSDatangPergi;
            }
            else
            {
                int idNode = playerGraph.getNodeIdByDatang(time);
                Brush newFill;
                if (idNode != 0)
                {
                    newFill = System.Windows.Media.Brushes.Blue;
                }
                else
                {
                    idNode = playerGraph.getNodeIdByPergi(time);
                    newFill = System.Windows.Media.Brushes.Red;
                }
                string nodeName = "node" + idNode;
                foreach (Ellipse el in P_Canvas.Children.OfType<Ellipse>())
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
            //queryFilePlayer = queryBox.Text;

            playerQuery = Solver.solveFile(playerGraph, queryFilePlayer);
            nQueryPlayer = 0;
            nNodePlayer = 0;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Start();
            timer.Tick += traverseSolution;
        }

        void traverseSolution(object sender, EventArgs e)
        {
            TextBlock status = new TextBlock();
            status.Height = 18;
            status.Width = 150;
            //cek.Text = watcherQuery[i].Count().ToString();
            status.FontSize = 10;
            Canvas.SetLeft(status, 300);
            Canvas.SetTop(status, 10);
            status.Foreground = new SolidColorBrush(Colors.LightGray);
            //status.Foreground = 
            P_Canvas.Children.Add(status);

            if (nQueryPlayer == playerQuery.Length)
            {
                timer.Stop();
                timer.Tick -= traverseSolution;
                
            }
            else
            {

                if (nNodePlayer == 0)
                {
                    foreach (Ellipse el in P_Canvas.Children.OfType<Ellipse>())
                    {
                        el.Fill = System.Windows.Media.Brushes.Red;
                    }
                }
                if (playerQuery[nQueryPlayer].Count != 0)
                {

                    int queryLine = nQueryPlayer + 1;
                    status.Text = "  STATUS: YES FOR QUERY #" + queryLine;
                    status.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE6E6E6"));
                    status.Foreground = new SolidColorBrush(Colors.Green);
                    foreach (Ellipse el in P_Canvas.Children.OfType<Ellipse>())
                    {
                        string nodeName = "node" + playerQuery[nQueryPlayer].ToArray()[nNodePlayer];
                        if (el.Name == nodeName)
                        {
                            el.Fill = System.Windows.Media.Brushes.Green;
                        }

                    }
                    nNodePlayer++;
                    if (nNodePlayer == playerQuery[nQueryPlayer].Count)
                    {
                        nNodePlayer = 0;
                        nQueryPlayer++;
                    }
                    //status.Text = String.Empty;

                }
                else
                {
                    int queryLine = nQueryPlayer + 1;
                    status.Text = "  STATUS: NO FOR QUERY #" + queryLine;
                    status.Foreground = new SolidColorBrush(Colors.DarkRed);
                    status.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE6E6E6"));
                    nQueryPlayer++;
                }

            }

        }

        private void backTo(object sender, RoutedEventArgs e)
        {
            Player2 p = new Player2(graphFilePlayer);
            ((MainWindow)Application.Current.MainWindow).Content = p;
        }

        private void backToMainMenu(object sender, RoutedEventArgs e)
        {
            ChooseOption c = new ChooseOption();
            ((MainWindow)Application.Current.MainWindow).Content = c;
        }
    }
}

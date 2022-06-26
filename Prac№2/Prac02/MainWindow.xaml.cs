using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prac02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static double[] Distance(int[,] LocationCity, int[,] ways, int popAmount)
        {
            double[] distances = new double[popAmount * 2];
            for (int i = 0; i < popAmount * 2; i++)
            {
                double dist = 0;
                double a,b;
                a = b = 0;
                for (int j = 0; j < LocationCity.GetLength(0); j++)
                {
                    if (j != LocationCity.GetLength(0) - 1)
                    {
                        a = Math.Abs(LocationCity[ways[i, j], 0] - LocationCity[ways[i, j + 1], 0]);
                        b = Math.Abs(LocationCity[ways[i, j], 1] - LocationCity[ways[i, j + 1], 1]);
                    }
                    else
                    {
                        a = Math.Abs(LocationCity[ways[i, j], 0] - LocationCity[ways[i, 0], 0]);
                        b = Math.Abs(LocationCity[ways[i, j], 1] - LocationCity[ways[i, 0], 1]);
                    }
                    double c = Math.Sqrt(a * a + b * b);
                    dist += c;
                }
                distances[i] = dist;
            }
            return distances;
        }

        static Random rnd = new Random();
        static Grid TempGrid = new Grid();

        public void Draw (int[,] loc, int citiesAmount, int[,] way)
        {
            Grid myGrid = new Grid();
            myGrid.Children.Remove(TempGrid);
            TempGrid.Children.Clear();
            Rectangle rec = new Rectangle();
            rec.Stroke = Brushes.Black;
            rec.Fill = Brushes.White;
            rec.Margin = new Thickness(300, 50, 0, 0);
            rec.Height = 420;
            rec.Width = 420;
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Top;
            myGrid.Children.Add(rec);
            for (int i =0; i< citiesAmount; i++)
            {
                Ellipse Ellipse = new Ellipse();
                Ellipse.Stroke = Brushes.Red;
                Ellipse.Fill = Brushes.Red;
                Ellipse.HorizontalAlignment = HorizontalAlignment.Left;
                Ellipse.VerticalAlignment = VerticalAlignment.Top;
                Ellipse.Margin = new Thickness(loc[i, 0]+300, loc[i, 1]+50, 0, 0);
                Ellipse.Height = 20;
                Ellipse.Width = 20;
                myGrid.Children.Add(Ellipse);
            }
            for(int i =0; i< citiesAmount - 1; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.Black;
                myLine.X1 = loc[way[0,i], 0]+300+6;
                myLine.X2 = loc[way[0,i + 1], 0]+300+6;
                myLine.Y1 = loc[way[0,i], 1]+50+6;
                myLine.Y2 = loc[way[0,i + 1], 1]+50+6;
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Top;
                myLine.StrokeThickness = 2.5;
                myGrid.Children.Add(myLine);
            }
            Line myLine2 = new Line();
            myLine2.Stroke = System.Windows.Media.Brushes.Black;
            myLine2.X1 = loc[way[0, citiesAmount - 1], 0] + 300 + 6;
            myLine2.X2 = loc[way[0, 0], 0] + 300 + 6;
            myLine2.Y1 = loc[way[0, citiesAmount - 1], 1] + 50 + 6;
            myLine2.Y2 = loc[way[0, 0], 1] + 50 + 6;
            myLine2.HorizontalAlignment = HorizontalAlignment.Left;
            myLine2.VerticalAlignment = VerticalAlignment.Top;
            myLine2.StrokeThickness = 2.5;
            myGrid.Children.Add(myLine2);

            WindowGrid.Children.Add(myGrid);
            TempGrid = myGrid;
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            Stop.IsEnabled = true;
            int citiesAmount = int.Parse(cities.Text);
            int popAmt = int.Parse(pop.Text);
            int[,] ways = new int[popAmt * 2, citiesAmount];
            int[,] loc = new int[citiesAmount, 2];
            int iterations = int.Parse(num_iter.Text);
            double mutationChance = double.Parse(mut.Text);

            for (int i = 0; i < citiesAmount; i++)
            {
                loc[i, 0] = rnd.Next(400);
                loc[i, 1] = rnd.Next(400);
            }

            for (int i = 0; i < popAmt; i++)
            {
                List<int> checkCities = new List<int>();
                for (int j = 0; j < citiesAmount; j++)
                {
                x1:
                    int tempCity = rnd.Next(citiesAmount);
                    if (!checkCities.Contains(tempCity))
                    {
                        checkCities.Add(tempCity); ways[i, j] = tempCity;
                    }
                    else goto x1;
                }
            }

            for (int it = 0; it < iterations; it++)
            {
                for (int m = 0; m < popAmt; m++)
                {
                    int chr1 = rnd.Next(popAmt);
                    int chr2 = rnd.Next(popAmt);
                    int crossoverPoint = 1 + rnd.Next(popAmt - 2);
                    int[] temp1 = new int[citiesAmount * 2];
                    int[] temp2 = new int[citiesAmount * 2];

                    for (int n = 0; n < citiesAmount; n++)
                    {
                        if (n <= crossoverPoint)
                        {
                            temp1[n] = ways[chr1, n];
                            temp2[n] = ways[chr2, n];
                        }
                        else
                        {
                            temp1[n] = ways[chr2, n];
                            temp2[n] = ways[chr1, n];
                        }
                    }
                    for (int k = citiesAmount; k < citiesAmount * 2; k++)
                    {
                        temp1[k] = temp2[k - citiesAmount];
                        temp2[k] = temp1[k - citiesAmount];
                    }

                    int[] temp3 = new int[citiesAmount];
                    int[] temp4 = new int[citiesAmount];
                    int l = 0;
                    int p = 0;
                    List<int> check1 = new List<int>();
                    List<int> check2 = new List<int>();

                    for (int z = 0; z < citiesAmount * 2; z++)
                    {
                        if (!check1.Contains(temp1[z]))
                        {
                            temp3[l] = temp1[z];
                            l++;
                            check1.Add(temp1[z]);
                        }
                        if (!check2.Contains(temp2[z]))
                        {
                            temp4[p] = temp2[z];
                            p++;
                            check2.Add(temp2[z]);
                        }
                    }
                    if (rnd.NextDouble() <= 0.5)
                        for (int o = 0; o < citiesAmount; o++)
                            ways[popAmt + m, o] = temp3[o];
                    else
                        for (int o = 0; o < citiesAmount; o++)
                            ways[popAmt + m, o] = temp4[o];

                    if (rnd.NextDouble() <= mutationChance)
                    {
                    x2:
                        int point1 = 1 + rnd.Next(citiesAmount - 2);
                        int point2 = 1 + rnd.Next(citiesAmount - 2);
                        if (point1 == point2) goto x2;

                        if (point1 > point2)
                        {
                            int buf = point1;
                            point1 = point2;
                            point2 = buf;
                        }
                        int[] array = new int[point2-point1 + 1];
                        int u = 0;
                        for (int f = 0; f < citiesAmount; f++)
                            if (f >= point1 && f <= point2)
                            {
                                array[u] = ways[popAmt + m, f];
                                u++;
                            }
                        Array.Reverse(array);
                        u = 0;
                        for (int f = 0; f < citiesAmount; f++)
                            if (f >= point1 && f <= point2)
                            {
                                ways[popAmt + m, f] = array[u];
                                u++;
                            }
                    }
                }
                double[] distances = Distance(loc, ways, popAmt);
                bool swaped = true;
                while (swaped == true)
                {
                    swaped = false;
                    for (int i = 0; i < popAmt * 2 - 1; i++)
                    {
                        if (distances[i] > distances[i + 1])
                        {
                            double distBuf = distances[i];
                            distances[i] = distances[i + 1];
                            distances[i + 1] = distBuf;
                            int[] wayTemp = new int[citiesAmount];
                            for (int j = 0; j < citiesAmount; j++)
                            {
                                wayTemp[j] = ways[i, j];
                                ways[i, j] = ways[i + 1, j];
                                ways[i + 1, j] = wayTemp[j];
                            }
                            swaped = true;
                        }
                    }
                }
                if(it % 10 == 0)
                {
                    await Task.Delay(1);
                    if (Stop.IsEnabled == false)
                        break;
                    iter.Content = it;
                    dist.Content = distances[0];
                    Draw(loc, citiesAmount, ways);
                    await Task.Delay(1);
                }
            }
            Start.IsEnabled = true;
            Stop.IsEnabled = false;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Stop.IsEnabled = false;
            Start.IsEnabled = true;
        }
    }
}

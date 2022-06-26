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
using System.Windows.Shapes;

namespace FirstWPFApp
{
    /// <summary>
    /// Логика взаимодействия для ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        TextBox Field = new TextBox();
        Button B = new Button();
        Button[,] Button = new Button[5,4];
        static double temp;
        static double temp_last;
        static double total;
        static string act;

        public ThirdWindow()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            Title = "Калькулятор";
            ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.White);

            Grid myGrid = new Grid();
            myGrid.Width = 500;
            myGrid.Height = 620;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            RowDefinition[] rows = new RowDefinition[7];
            ColumnDefinition[] cols = new ColumnDefinition[4];
            for (int i = 0; i < 7; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            Field = new TextBox();
            Field.FontSize = 34;
            Field.TextWrapping = TextWrapping.Wrap;
            Field.TextChanged += Field_TextChanged;
            Grid.SetRow(Field, 0);
            Grid.SetColumn(Field, 0);
            Grid.SetColumnSpan(Field, 4);
            myGrid.Children.Add(Field);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                {
                    Button[i,j] = new Button();
                    Button[i,j].FontSize = 30;
                    Button[i,j].Width = 116;
                    Button[i,j].Height = 80;
                    Grid.SetRow(Button[i,j], i+1);
                    Grid.SetColumn(Button[i,j], j);
                    myGrid.Children.Add(Button[i,j]);
                }
            Button[0, 0].IsEnabled = false;
            Button[0, 1].Content = "=";
            Button[0, 2].Content = "C";
            Button[0, 3].Content = "Delete";
            Button[1, 0].Content = "7";
            Button[1, 1].Content = "8";
            Button[1, 2].Content = "9";
            Button[1, 3].Content = "/";
            Button[2, 0].Content = "4";
            Button[2, 1].Content = "5";
            Button[2, 2].Content = "6";
            Button[2, 3].Content = "*";
            Button[3, 0].Content = "1";
            Button[3, 1].Content = "2";
            Button[3, 2].Content = "3";
            Button[3, 3].Content = "-";
            Button[4, 0].Content = "+/-";
            Button[4, 1].Content = "0";
            Button[4, 2].Content = ",";
            Button[4, 3].Content = "+";

            Button[0, 1].Click += Total_Click;
            Button[0, 2].Click += C_Click;
            Button[0, 3].Click += Delete_Click;
            Button[1, 0].Click += Seven_Click;
            Button[1, 1].Click += Eight_Click;
            Button[1, 2].Click += Nine_Click;
            Button[1, 3].Click += Divide_Click;
            Button[2, 0].Click += Four_Click;
            Button[2, 1].Click += Five_Click;
            Button[2, 2].Click += Six_Click;
            Button[2, 3].Click += Multiply_Click;
            Button[3, 0].Click += One_Click;
            Button[3, 1].Click += Two_Click;
            Button[3, 2].Click += Three_Click;
            Button[3, 3].Click += Minus_Click;
            Button[4, 0].Click += Znak_Click;
            Button[4, 1].Click += Zero_Click;
            Button[4, 2].Click += Dot_Click;
            Button[4, 3].Click += Plus_Click;

            B = new Button();
            B.FontSize = 15;
            B.Width = 100;
            B.Height = 70;
            B.Content = "Вихід";
            B.Click += GoToMainWin_Click;
            B.Background = new SolidColorBrush(Colors.Red);
            Grid.SetRow(B, 6);
            Grid.SetColumn(B, 3);
            myGrid.Children.Add(B);

            this.Content = myGrid;
            Show();
        }

        private void GoToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "9";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = Field.Text + "0";
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            string last = Field.Text.Substring(Field.Text.LastIndexOf("\n") + 1, Field.Text.Length - 1 - Field.Text.LastIndexOf("\n"));
            if (!last.Contains(","))
                Field.Text = Field.Text + ",";
        }

        private void Znak_Click(object sender, RoutedEventArgs e)
        {
            string last = Field.Text.Substring(Field.Text.LastIndexOf("\n") + 1, Field.Text.Length - 1 - Field.Text.LastIndexOf("\n"));
            if (!last.Contains("-"))
            {
                if (Field.Text.Contains("\n"))
                    Field.Text = Field.Text.Insert(Field.Text.LastIndexOf("\n") + 1, "-");
                else
                    Field.Text = "-" + Field.Text;
            }
            else
                Field.Text = Field.Text.Remove(Field.Text.LastIndexOf("-"),1);
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            temp_last = temp;
            if (Field.Text.LastIndexOf("\n") == Field.Text.Length - 1)
                Field.Text = Field.Text.Remove(Field.Text.Length - 3, 3);
            Field.Text = Field.Text + " +\n";
            act = "+";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            temp_last = temp;
            if (Field.Text.LastIndexOf("\n") == Field.Text.Length - 1)
                Field.Text = Field.Text.Remove(Field.Text.Length - 3, 3);
            Field.Text = Field.Text + " -\n";
            act = "-";
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            temp_last = temp;
            if (Field.Text.LastIndexOf("\n") == Field.Text.Length - 1)
                Field.Text = Field.Text.Remove(Field.Text.Length - 3, 3);
            Field.Text = Field.Text + " *\n";
            act = "*";
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            temp_last = temp;
            if (Field.Text.LastIndexOf("\n") == Field.Text.Length - 1)
                Field.Text = Field.Text.Remove(Field.Text.Length - 3, 3);
            Field.Text = Field.Text + " /\n";
            act = "/";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Field.Text.Length != 0)
                Field.Text = Field.Text.Remove(Field.Text.Length - 1, 1); 
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = "";
        }

        private void Total_Click(object sender, RoutedEventArgs e)
        {
            if (act == "+")
                total = temp_last + temp;
            else if (act == "-")
                total = temp_last - temp;
            else if (act == "*")
                total = temp_last * temp;
            else if (act == "/") 
                total = temp_last / temp;
            Field.Text = Convert.ToString(total);
        }

        private void Field_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Field.Text.Contains("\n"))
            {
                string last = Field.Text.Substring(Field.Text.LastIndexOf("\n")+1, Field.Text.Length - 1 - Field.Text.LastIndexOf("\n"));
                if(last == "")
                    temp = temp_last;
                else
                {
                    if (last.Contains(","))
                        temp = Convert.ToDouble(last + "0");
                    else
                        temp = Convert.ToDouble(last);
                }
            }
            else
            {
                if (Field.Text.Contains(","))
                    temp = Convert.ToDouble(Field.Text + "0");
                else
                {
                    if(Field.Text == "")
                        temp = temp_last;
                    else
                        temp = Convert.ToDouble(Field.Text);
                }
                   
            }
        }
    }
}

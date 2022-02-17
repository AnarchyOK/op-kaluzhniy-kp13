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
        static double temp;
        static double temp_last;
        static double total;
        static string act;

        public ThirdWindow()
        {
            InitializeComponent();
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
            Empty.Content = "temp=" + temp + "\ntemp_last=" + temp_last;
        }
    }
}

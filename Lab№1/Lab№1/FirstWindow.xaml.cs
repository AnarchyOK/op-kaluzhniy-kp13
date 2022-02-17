using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Windows;

namespace FirstWPFApp
{

    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        static StreamReader DataFile;
        static StreamWriter DB;

        public FirstWindow()
        {
            InitializeComponent();
            try
            {
                DB = new StreamWriter("DB.txt", true);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return;
            }
            
        }

        private void GoToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
            DB.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string student = " " + TB1.Text + "  |  " + TB2.Text + "  |  " + TB3.Text + "  |  " + TB4.Text;
            DB.WriteLine(student);
            TB1.Text = TB2.Text = TB3.Text = TB4.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            DB.Close();
            DataFile = new StreamReader("DB.txt");
            string ID = " " + Delete.Text + " ";
            Delete.Text = "Не знайдено";
            while (!DataFile.EndOfStream)
            {
                string line = DataFile.ReadLine();
                if (line.Contains(ID))
                {
                    Delete.Text = "Видалено";
                }
                else
                {
                    temp.Add(line);
                }
            }
            DataFile.Close();
            DB = new StreamWriter("DB.txt");
            for (int i = 0; i < temp.Count; i++) 
            {
                DB.WriteLine(temp[i]);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            DB.Close();
            DB = new StreamWriter("DB.txt");
        }
    }
}

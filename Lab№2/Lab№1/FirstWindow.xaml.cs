using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FirstWPFApp
{

    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        static StreamReader DataFile;
        static StreamWriter DB;
        Button[] Button = new Button[4];
        TextBox[] TB = new TextBox[5];

        public FirstWindow()
        {
            InitializeComponent();
            InitControls();
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
        private void InitControls()
        {
            Title = "База даних студентів";
            ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.LightGray);

            Grid myGrid = new Grid();
            myGrid.Width = 850;
            myGrid.Height = 350;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            RowDefinition[] rows = new RowDefinition[7];
            ColumnDefinition[] cols = new ColumnDefinition[5];

            for (int i = 0; i < 7; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            double t = 1.5;
            for (int i = 0; i < 7; i++)
            {
                rows[i].Height = new GridLength(t,GridUnitType.Star);
                if (t == 1.5)
                {
                    t = 1;
                }
                else
                {
                    t = 1.5;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            cols[0].Width = new GridLength(2, GridUnitType.Star);

            SolidColorBrush grey = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            int l = 0;
            for (int i = 0; i < 4; i++)
            {
                TB[i] = new TextBox();
                TB[i].FontSize = 18;
                TB[i].TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(TB[i],l);
                Grid.SetColumn(TB[i], 0);
                l += 2;
                myGrid.Children.Add(TB[i]);
            }
            TB[0].Text = "Введіть ID...";
            TB[1].Text = "Введіть ПІБ...";
            TB[2].Text = "Введіть спеціальність...";
            TB[3].Text = "Введіть курс...";

            TB[4] = new TextBox();
            TB[4].Text = "Введіть ID(Для видалення!!!)...";
            TB[4].FontSize = 16;
            TB[4].TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(TB[4], 0);
            Grid.SetColumn(TB[4], 4);
            myGrid.Children.Add(TB[4]);

            int l2 = 2;
            for (int i = 0; i < 3; i++)
            {
                Button[i] = new Button();
                Button[i].FontSize = 14;
                Button[i].Width = 140;
                Button[i].Height = 50;
                Grid.SetRow(Button[i], 7);
                Grid.SetColumn(Button[i], l2);
                l2++;
                myGrid.Children.Add(Button[i]);
            }

            Button[0].FontSize = 18;
            Button[3] = new Button();
            Button[3].FontSize = 18;
            Button[3].Width = 140;
            Button[3].Height = 55;
            Button[3].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Grid.SetRow(Button[3], 1);
            Grid.SetRowSpan(Button[3], 2);
            Grid.SetColumn(Button[3], 4);
            myGrid.Children.Add(Button[3]);

            Button[0].Content = "Записати";
            Button[1].Content = "Очистити базу даних";
            Button[2].Content = "До головного вікна";
            Button[3].Content = "Видалити";

            Button[0].Click += Button_Click;
            Button[1].Click += Button_Click2;
            Button[2].Click += GoToMainWin_Click;
            Button[3].Click += Button_Click_1;

            this.Content = myGrid;
            Show();
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
            string student = " " + TB[0].Text + "  |  " + TB[1].Text + "  |  " + TB[2].Text + "  |  " + TB[3].Text;
            DB.WriteLine(student);
            TB[0].Text = TB[1].Text = TB[2].Text = TB[3].Text = "";
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            DB.Close();
            DataFile = new StreamReader("DB.txt");
            string ID = " " +TB[4].Text + " ";
            TB[4].Text = "Не знайдено";
            while (!DataFile.EndOfStream)
            {
                string line = DataFile.ReadLine();
                if (line.Contains(ID))
                {
                    TB[4].Text = "Видалено";
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

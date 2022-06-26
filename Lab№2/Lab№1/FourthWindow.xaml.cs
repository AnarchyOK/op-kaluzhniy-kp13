using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FirstWPFApp
{
    /// <summary>
    /// Логика взаимодействия для FourthWindow.xaml
    /// </summary>
    public partial class FourthWindow : Window
    {
        Button Button = new Button();
        TextBox TB = new TextBox();
        public FourthWindow()
        {
            InitializeComponent();
            InitControls();
        }
        private void InitControls()
        {
            Title = "Info";
            ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.LightGray);

            Grid myGrid = new Grid();
            myGrid.Width = 580;
            myGrid.Height = 250;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            RowDefinition[] rows = new RowDefinition[2];
            ColumnDefinition[] cols = new ColumnDefinition[1];

            for (int i = 0; i < 2; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            rows[0].Height = new GridLength(3, GridUnitType.Star);
            for (int i = 0; i < 1; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            TB = new TextBox();
            TB.FontSize = 18;
            TB.Text = "Автор: Калюжний Олександр Петрович;\nстудент 1-го курсу;\nгрупа КП-13;\n2022©";
            TB.IsReadOnly = true;
            TB.TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(TB, 0);
            Grid.SetColumn(TB, 0);
            myGrid.Children.Add(TB);

            Button = new Button();
            Button.FontSize = 18;
            Button.Content = "До головного вікна";
            Button.Click += GoToMainWin_Click;
            Grid.SetRow(Button, 1);
            Grid.SetColumn(Button, 0);
            myGrid.Children.Add(Button);


            this.Content = myGrid;
            Show();
        }

        private void GoToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace FirstWPFApp
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        ComboBox[,] CB = new ComboBox[5,5];
        Button[] Bs = new Button[2];
        static int[,] mat = new int[5,5];

        public SecondWindow()
        {
            InitializeComponent();
            InitControls();
            int k = 2;
            for (int i = 0; i <= 4; i++)
                for (int j = 0; j <= 4; j++)
                {
                    mat[i, j] = k;
                    k++;
                }
        }
        private void InitControls()
        {
            Title = "Хрестики-Нулики";
            ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.White);

            Grid myGrid = new Grid();
            myGrid.Width = 780;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;
            RowDefinition[] rows = new RowDefinition[5];
            ColumnDefinition[] cols = new ColumnDefinition[6];

            for (int i = 0; i < 5; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
           
            for (int i = 0; i < 6; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            cols[5].Width = new GridLength(3, GridUnitType.Star);

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    CB[i, j] = new ComboBox();
                    CB[i, j].Items.Add(" X");
                    CB[i, j].Items.Add(" O");
                    CB[i, j].FontSize = 55;
                    CB[i, j].SelectionChanged += SelectionChanged;

                }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    Grid.SetRow(CB[i, j], i);
                    Grid.SetColumn(CB[i, j], j);
                }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    myGrid.Children.Add(CB[i, j]);
                }
            Bs[0] = new Button();
            Bs[1] = new Button();
            Bs[0].Content = "Очистити поля";
            Bs[1].Content = "До головного вікна";
            Bs[0].Click += But_Click;
            Bs[1].Click += GoToMainWin_Click;
            Bs[0].Width = 260;
            Bs[0].Height = 80;
            Bs[1].Width = 260;
            Bs[1].Height = 80;
            Grid.SetRow(Bs[0], 0);
            Grid.SetColumn(Bs[0], 5);
            Grid.SetRow(Bs[1], 4);
            Grid.SetColumn(Bs[1], 5);
            myGrid.Children.Add(Bs[0]);
            myGrid.Children.Add(Bs[1]);

            this.Content = myGrid;
            Show();
        }

        private void GoToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i_l= 0; int j_l = 0;
            ComboBox cb = (ComboBox)sender;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if(CB[i, j].Equals(cb))
                    {
                        i_l = i;
                        j_l = j;
                    }
                }
            if (cb.SelectedIndex == 0)
            {
                mat[i_l, j_l] = 0;
            }
            else if (cb.SelectedIndex == 1)
            {
                mat[i_l, j_l] = 1;
            }
            Check();
            cb.IsEnabled = false;
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            int k = 2;
            for (int i = 0; i <= 4; i++)
                for (int j = 0; j <= 4; j++)
                {
                    mat[i, j] = k;
                    k++;
                }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    CB[i, j].SelectedIndex = -1;
                    CB[i, j].IsEnabled = true;
                }
        }
        static void Check()
        {
            
            int rah1 = 0;
            int rah2 = 0;
            if (mat[0, 0] == mat[1, 1] && mat[1, 1] == mat[2, 2] && mat[2, 2] == mat[3, 3] && mat[3, 3] == mat[4, 4])
            {
                string winner;
                if (mat[0, 0] == 0)
                    winner = "Хрестики";
                else
                    winner = "Нолики";
                MessageBox.Show("Виграли " + winner);
            }
            if (mat[0, 4] == mat[1, 3] && mat[1, 3] == mat[2, 2] && mat[2, 2] == mat[3, 1] && mat[3, 1] == mat[4, 0])
            {
                string winner;
                if (mat[0, 4] == 0)
                    winner = "Хрестики";
                else
                    winner = "Нолики";
                MessageBox.Show("Виграли " + winner);
            }
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (mat[i, j] == 0)
                        rah1++;
                    else if (mat[i, j] == 1)
                        rah2++;

                    if (rah1 == 5 || rah2 == 5)
                    {
                        string winner;
                        if (mat[i, j] == 0)
                            winner = "Хрестики";
                        else
                            winner = "Нолики";
                        MessageBox.Show("Виграли " + winner);
                    }
                }
                rah1 = rah2 = 0;
            }
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (mat[j, i] == 0)
                        rah1++;
                    else if (mat[j, i] == 1)
                        rah2++;

                    if (rah1 == 5 || rah2 == 5)
                    {
                        string winner;
                        if (mat[j, i] == 0)
                            winner = "Хрестики";
                        else
                            winner = "Нолики";
                        MessageBox.Show("Виграли " + winner);
                    }
                }
                rah1 = rah2 = 0;
            }

        }
    }
}

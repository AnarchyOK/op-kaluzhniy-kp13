using System.Windows;
using System.Windows.Controls;


namespace FirstWPFApp
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        static int[,] mat = new int[5,5];

        public SecondWindow()
        {
            InitializeComponent();
            int k = 2;
            for (int i = 0; i <= 4; i++)
                for (int j = 0; j <= 4; j++)
                {
                    mat[i, j] = k;
                    k++;
                }
        }

        private void GoToMainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void C11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C11.SelectedIndex == 0)
                mat[0, 0] = 0;
            else if(C11.SelectedIndex == 1)
                mat[0, 0] = 1;
            Check();
            C11.IsEnabled = false;
        }

        private void C12_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C12.SelectedIndex == 0)
                mat[0, 1] = 0;
            else if (C12.SelectedIndex == 1)
                mat[0, 1] = 1;
            Check();
            C12.IsEnabled = false;
        }

        private void C13_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C13.SelectedIndex == 0)
                mat[0, 2] = 0;
            else if (C13.SelectedIndex == 1)
                mat[0, 2] = 1;
            Check();
            C13.IsEnabled = false;
        }

        private void C14_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C14.SelectedIndex == 0)
                mat[0, 3] = 0;
            else if (C14.SelectedIndex == 1)
                mat[0, 3] = 1;
            Check();
            C14.IsEnabled = false;
        }

        private void C15_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C15.SelectedIndex == 0)
                mat[0, 4] = 0;
            else if (C15.SelectedIndex == 1)
                mat[0, 4] = 1;
            Check();
            C15.IsEnabled = false;
        }

        private void C21_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C21.SelectedIndex == 0)
                mat[1, 0] = 0;
            else if (C21.SelectedIndex == 1)
                mat[1, 0] = 1;
            Check();
            C21.IsEnabled = false;
        }

        private void C22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C22.SelectedIndex == 0)
                mat[1, 1] = 0;
            else if (C22.SelectedIndex == 1)
                mat[1, 1] = 1;
            Check();
            C22.IsEnabled = false;
        }

        private void C23_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C23.SelectedIndex == 0)
                mat[1, 2] = 0;
            else if (C23.SelectedIndex == 1)
                mat[1, 2] = 1;
            Check();
            C23.IsEnabled = false;
        }

        private void C24_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C24.SelectedIndex == 0)
                mat[1, 3] = 0;
            else if (C24.SelectedIndex == 1)
                mat[1, 3] = 1;
            Check();
            C24.IsEnabled = false;
        }

        private void C25_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C25.SelectedIndex == 0)
                mat[1, 4] = 0;
            else if (C25.SelectedIndex == 1)
                mat[1, 4] = 1;
            Check();
            C25.IsEnabled = false;
        }

        private void C31_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C31.SelectedIndex == 0)
                mat[2, 0] = 0;
            else if (C31.SelectedIndex == 1)
                mat[2, 0] = 1;
            Check();
            C31.IsEnabled = false;
        }

        private void C32_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C32.SelectedIndex == 0)
                mat[2, 1] = 0;
            else if (C32.SelectedIndex == 1)
                mat[2, 1] = 1;
            Check();
            C32.IsEnabled = false;
        }

        private void C33_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C33.SelectedIndex == 0)
                mat[2, 2] = 0;
            else if (C33.SelectedIndex == 1)
                mat[2, 2] = 1;
            Check();
            C33.IsEnabled = false;
        }

        private void C34_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C34.SelectedIndex == 0)
                mat[2, 3] = 0;
            else if (C34.SelectedIndex == 1)
                mat[2, 3] = 1;
            Check();
            C34.IsEnabled = false;
        }

        private void C35_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C35.SelectedIndex == 0)
                mat[2, 4] = 0;
            else if (C35.SelectedIndex == 1)
                mat[2, 4] = 1;
            Check();
            C35.IsEnabled = false;
        }

        private void C41_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C41.SelectedIndex == 0)
                mat[3, 0] = 0;
            else if (C41.SelectedIndex == 1)
                mat[3, 0] = 1;
            Check();
            C41.IsEnabled = false;
        }

        private void C42_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C42.SelectedIndex == 0)
                mat[3, 1] = 0;
            else if (C42.SelectedIndex == 1)
                mat[3, 1] = 1;
            Check();
            C42.IsEnabled = false;
        }

        private void C43_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C43.SelectedIndex == 0)
                mat[3, 2] = 0;
            else if (C43.SelectedIndex == 1)
                mat[3, 2] = 1;
            Check();
            C43.IsEnabled = false;
        }

        private void C44_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C44.SelectedIndex == 0)
                mat[3, 3] = 0;
            else if (C44.SelectedIndex == 1)
                mat[3, 3] = 1;
            Check();
            C44.IsEnabled = false;
        }

        private void C45_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C45.SelectedIndex == 0)
                mat[3, 4] = 0;
            else if (C45.SelectedIndex == 1)
                mat[3, 4] = 1;
            Check();
            C45.IsEnabled = false;
        }

        private void C51_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C51.SelectedIndex == 0)
                mat[4, 0] = 0;
            else if (C51.SelectedIndex == 1)
                mat[4, 0] = 1;
            Check();
            C51.IsEnabled = false;
        }

        private void C52_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C52.SelectedIndex == 0)
                mat[4, 1] = 0;
            else if (C52.SelectedIndex == 1)
                mat[4, 1] = 1;
            Check();
            C52.IsEnabled = false;
        }

        private void C53_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C53.SelectedIndex == 0)
                mat[4, 2] = 0;
            else if (C53.SelectedIndex == 1)
                mat[4, 2] = 1;
            Check();
            C53.IsEnabled = false;
        }

        private void C54_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C54.SelectedIndex == 0)
                mat[4, 3] = 0;
            else if (C54.SelectedIndex == 1)
                mat[4, 3] = 1;
            Check();
            C54.IsEnabled = false;
        }

        private void C55_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (C55.SelectedIndex == 0)
                mat[4, 4] = 0;
            else if (C55.SelectedIndex == 1)
                mat[4, 4] = 1;
            Check();
            C55.IsEnabled = false;
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
            C11.SelectedIndex = -1; C11.IsEnabled = true;
            C12.SelectedIndex = -1; C12.IsEnabled = true;
            C13.SelectedIndex = -1; C13.IsEnabled = true;
            C14.SelectedIndex = -1; C14.IsEnabled = true;
            C15.SelectedIndex = -1; C15.IsEnabled = true;
            C21.SelectedIndex = -1; C21.IsEnabled = true;
            C22.SelectedIndex = -1; C22.IsEnabled = true;
            C23.SelectedIndex = -1; C23.IsEnabled = true;
            C24.SelectedIndex = -1; C24.IsEnabled = true;
            C25.SelectedIndex = -1; C25.IsEnabled = true;
            C31.SelectedIndex = -1; C31.IsEnabled = true;
            C32.SelectedIndex = -1; C32.IsEnabled = true;
            C33.SelectedIndex = -1; C33.IsEnabled = true; 
            C34.SelectedIndex = -1; C34.IsEnabled = true;
            C35.SelectedIndex = -1; C35.IsEnabled = true; 
            C41.SelectedIndex = -1; C41.IsEnabled = true;
            C42.SelectedIndex = -1; C42.IsEnabled = true;
            C43.SelectedIndex = -1; C43.IsEnabled = true;
            C44.SelectedIndex = -1; C44.IsEnabled = true;
            C45.SelectedIndex = -1; C45.IsEnabled = true;
            C51.SelectedIndex = -1; C51.IsEnabled = true;
            C52.SelectedIndex = -1; C52.IsEnabled = true;
            C53.SelectedIndex = -1; C53.IsEnabled = true;
            C54.SelectedIndex = -1; C54.IsEnabled = true;
            C55.SelectedIndex = -1; C55.IsEnabled = true;
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

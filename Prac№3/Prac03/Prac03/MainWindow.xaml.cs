using System.Windows;


namespace Prac03
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminModeWin aw = new AdminModeWin(this);
            aw.Show();
            Hide();
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserModeWin uw = new UserModeWin(this);
            uw.Show();
            Hide();
        }

    }
}

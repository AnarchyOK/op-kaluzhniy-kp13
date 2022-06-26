using System.Windows;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EditCinemas_Click(object sender, RoutedEventArgs e)
        {
            EditCinemas ex = new EditCinemas();
            Hide();
            ex.Show();
        }

        private void EditFilms_Click(object sender, RoutedEventArgs e)
        {
            EditFilms ex = new EditFilms();
            Hide();
            ex.Show();
        }

        private void EditActors_Click(object sender, RoutedEventArgs e)
        {
            EditActors ex = new EditActors();
            Hide();
            ex.Show();
        }

        private void Afisha_Click(object sender, RoutedEventArgs e)
        {
            Afisha af = new Afisha();
            Hide();
            af.Show();
        }

        private void Requests_Click(object sender, RoutedEventArgs e)
        {
            Requests ex = new Requests();
            Hide();
            ex.Show();
        }

        private void EditProdAndOperator_Click(object sender, RoutedEventArgs e)
        {
            EditProdAndOperator ex = new EditProdAndOperator();
            Hide();
            ex.Show();
        }

        private void EditSome_Click(object sender, RoutedEventArgs e)
        {
            EditSome ex = new EditSome();
            Hide();
            ex.Show();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWPFApp
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
            Application.Current.Shutdown();
        }

        private void Win1_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow mw = new FirstWindow();
            Hide();
            mw.Show();
        }

        private void Win2_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow sw = new SecondWindow();
            Hide();
            sw.Show();
        }

        private void Win3_Click(object sender, RoutedEventArgs e)
        {
            ThirdWindow tw = new ThirdWindow();
            Hide();
            tw.Show();
        }

        private void Win4_Click(object sender, RoutedEventArgs e)
        {
            FourthWindow fw = new FourthWindow();
            Hide();
            fw.Show();
        }


    }
}

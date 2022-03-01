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

namespace Prac_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string word;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void StudyModeBtn_Click(object sender, RoutedEventArgs e)
        {
            StudyModeWindow studyModeWindow = new StudyModeWindow();
            studyModeWindow.Show();
        }
        private void ProtectionModeBtn_Click(object sender,
        RoutedEventArgs e)
        {
            ProtectionModeWindow protectionModeWindow = new ProtectionModeWindow();
            protectionModeWindow.Show();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            word = Word.Text;
        }
    }
}

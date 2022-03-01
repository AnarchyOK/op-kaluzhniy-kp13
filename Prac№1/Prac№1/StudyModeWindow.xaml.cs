using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
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


namespace Prac_1
{
    /// <summary>
    /// Логика взаимодействия для StudyModeWindow.xaml
    /// </summary>
    public partial class StudyModeWindow : Window
    {
        static StreamReader DataFile;
        static StreamWriter DB;
        static string text;
        static int counter = 0;
        static int attempts = 0;
        static int r = 0;
        List<double> temp = new List<double>();
        Stopwatch stopWatch = new Stopwatch();
        List<double> tabl = new List<double>() { 4.3,3.18,2.77,2.57,2.44,2.36,2.30,2.26,2.22 };



        public StudyModeWindow()
        {
            InitializeComponent();
            VerifField.Text = MainWindow.word;
            stopWatch.Reset();
            text = "";
            counter = 0;
            attempts = 0;
            r = 0;
            DB = new StreamWriter("DB_Study.txt");
            DB.Close();
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            DB.Close();
        }

        private void InputField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DB = new StreamWriter("DB_Study.txt", true);
            TimeSpan ts;
            if (counter == 0)
            {
                stopWatch.Start();
                counter++;
            }
            else if (counter < MainWindow.word.Length-1)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                DB.Write(ts.TotalSeconds + "|");
                stopWatch.Restart();
                counter++;
            }
            else if (counter == MainWindow.word.Length - 1)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                DB.Write(ts.TotalSeconds + "|");
                counter++;
            }
            DB.Close();
        }

        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            SymbolCount.Content = InputField.Text.Length;
            if (InputField.Text == MainWindow.word)
            {
                stopWatch.Reset();
                counter = 0;
                InputField.Text = "";
                DB = new StreamWriter("DB_Study.txt", true);
                DB.WriteLine();
                DB.Close();
                if(Check_errors(r) == true)
                {
                    attempts++;
                }
                r++;
            }
            if (attempts == Convert.ToInt32(CountProtection.Text))
            {
                InputField.IsEnabled = false;
                DB = new StreamWriter("DB_Study.txt");
                DB.Write(text);
                DB.Close();
            }
            
        }
        private bool Check_errors(int R)
        {
            bool res = false;
            temp.Clear();
            DataFile = new StreamReader("DB_Study.txt");
            List<string> lines = new List<string>();
            for (int j = 0; j <= R; j++)
            {
                lines.Add(DataFile.ReadLine());
            }
            for (int i = 0; i < MainWindow.word.Length - 1; i++)
            {
                temp.Add(Convert.ToDouble(lines[lines.Count - 1].Split('|')[i]));
            }
            DataFile.Close();

            for (int i = 0; i < temp.Count; i++)
            {
                List<double> tet = new List<double>(temp);
                double y_i = tet[i];
                tet.RemoveAt(i);
                double M_i = 0;
                for (int j = 0; j < tet.Count; j++)
                {
                    M_i += tet[j];
                }
                M_i = M_i / tet.Count;
                double S2_i = 0;
                for (int j = 0; j < tet.Count; j++)
                {
                    S2_i += Math.Pow(tet[j] - M_i, 2);
                }
                S2_i = S2_i / (tet.Count - 1);
                double S_i = Math.Sqrt(S2_i);
                double t_p = Math.Abs(y_i - M_i) / S_i;
                if(t_p > tabl[MainWindow.word.Length - 5])
                {
                    res = false;
                    Test.Content = "Забраковано";
                    break;
                }
                else
                {
                    res = true;
                    Test.Content = "Зараховано";
                }                
            }

            if (res == true)
            {
                text = text + string.Join("|", temp) + "\n";
            }

            return res;
        }

    }
}

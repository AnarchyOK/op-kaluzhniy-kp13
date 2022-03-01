using System;
using System.IO;
using System.Diagnostics;
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
    /// Логика взаимодействия для ProtectionModeWindow.xaml
    /// </summary>
    public partial class ProtectionModeWindow : Window
    {
        static StreamReader DataFile;
        static StreamWriter DB_Protect;
        static string text;
        static int counter = 0;
        static int attempts = 0;
        static int r = 0;
        List<double> temp = new List<double>();
        List<double> temp2 = new List<double>();
        Stopwatch stopWatch = new Stopwatch();
        List<double> tabl = new List<double>() { 4.3, 3.18, 2.77, 2.57, 2.44, 2.36, 2.30, 2.26, 2.22 };
        List<double> S1 = new List<double>();
        List<double> S2 = new List<double>();
        List<double> M1 = new List<double>();
        List<double> M2 = new List<double>();

        public ProtectionModeWindow()
        {
            InitializeComponent();
            VerifField.Text = MainWindow.word;
            stopWatch.Reset();
            text = "";
            counter = 0;
            attempts = 0;
            r = 0;
            DB_Protect = new StreamWriter("DB_Protect.txt");
            DB_Protect.Close();
        }

        private void CloseProtectionMode_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            DB_Protect.Close();
        }

        private void InputField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DB_Protect = new StreamWriter("DB_Protect.txt", true);
            TimeSpan ts;
            if (counter == 0)
            {
                stopWatch.Start();
                counter++;
            }
            else if (counter < MainWindow.word.Length - 1)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                DB_Protect.Write(ts.TotalSeconds + "|");
                stopWatch.Restart();
                counter++;
            }
            else if (counter == MainWindow.word.Length - 1)
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                DB_Protect.Write(ts.TotalSeconds + "|");
                counter++;
            }
            DB_Protect.Close();
        }

        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            SymbolCount.Content = InputField.Text.Length;
            if (InputField.Text == MainWindow.word)
            {
                stopWatch.Reset();
                counter = 0;
                InputField.Text = "";
                DB_Protect = new StreamWriter("DB_Protect.txt", true);
                DB_Protect.WriteLine();
                DB_Protect.Close();
                if (Check_errors(r) == true)
                {
                    attempts++;
                }
                r++;
            }
            if (attempts == Convert.ToInt32(CountProtection.Text))
            {
                InputField.IsEnabled = false;
                DB_Protect = new StreamWriter("DB_Protect.txt");
                DB_Protect.Write(text);
                DB_Protect.Close();
                Check_similar();
            }
        }

        private bool Check_errors(int R)
        {
            bool res = false;
            temp.Clear();
            DataFile = new StreamReader("DB_Protect.txt");
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
                if (t_p > tabl[MainWindow.word.Length - 5])
                {
                    res = false;
                    break;
                }
                else
                {
                    res = true;
                }
            }
            if (res == true)
            {
                text = text + string.Join("|", temp) + "\n";
            }
            return res;
        }
        private void Check_similar()
        {
            temp.Clear(); temp2.Clear();
            DataFile = new StreamReader("DB_Study.txt");
            while (!DataFile.EndOfStream)
            {
                string[] Line = DataFile.ReadLine().Split('|');
                for (int i = 0; i < MainWindow.word.Length - 1; i++) 
                {
                    temp.Add(Convert.ToDouble(Line[i]));
                }
            }
            DataFile.Close();
            DataFile = new StreamReader("DB_Protect.txt");
            while (!DataFile.EndOfStream)
            {
                string[] Line = DataFile.ReadLine().Split('|');
                for (int i = 0; i < MainWindow.word.Length - 1; i++)
                {
                    temp2.Add(Convert.ToDouble(Line[i]));
                }
            }
            DataFile.Close();
            int k = 0;
            int l = MainWindow.word.Length - 1;
            for (int i = 0; i < temp.Count/ (MainWindow.word.Length-1); i++)
            {
                double M_i = 0;
                for (int j = k; j < l; j++) 
                {
                    M_i += temp[j];
                }
                M_i = M_i / l;
                M1.Add(M_i);
                double S2_i = 0;
                for (int j = k; j < l; j++)
                {
                    S2_i += Math.Pow(temp[j] - M_i, 2);
                }
                S2_i = S2_i / (l - 1);
                S1.Add(S2_i);
                k += MainWindow.word.Length-1;
                l += MainWindow.word.Length-1;
            }
            int k2 = 0;
            int l2 = MainWindow.word.Length - 1;
            for (int i = 0; i < Convert.ToInt32(CountProtection.Text); i++)
            {
                double M_i = 0;
                for (int j = k2; j < l2; j++)
                {
                    M_i += temp2[j];
                }
                M_i = M_i / l2;
                M2.Add(M_i);
                double S2_i = 0;
                for (int j = k2; j < l2; j++)
                {
                    S2_i += Math.Pow(temp2[j] - M_i, 2);
                }
                S2_i = S2_i / (l2 - 1);
                S2.Add(S2_i);
                k2 += MainWindow.word.Length-1;
                l2 += MainWindow.word.Length-1;
            }
            int f = 0;
            for (int i = 0; i < S1.Count; i++)
                for (int j = 0; j < S2.Count; j++) 
                {
                    double F = Math.Max(S1[i], S2[j]) / Math.Min(S1[i], S2[j]);
                    if (F > 9.28) 
                    {
                        f++;
                    }
                }
            if (f > (1.0 * S1.Count * S2.Count) / 2) 
            {
                DispField.Content = "Неоднорідні";
            }
            else
            {
                DispField.Content = "Однорідні";
            }
            int r = 0;
            for (int i = 0; i < S1.Count; i++)
            {
                for (int j = 0; j < S2.Count; j++)
                {
                    double n = MainWindow.word.Length - 1;
                    double S = Math.Sqrt(((S1[i] + S2[j]) * (n - 1)) / (2 * n));
                    double t_p = Math.Abs(M1[i] - M2[j]) / (S * Math.Sqrt(2 / n));
                    if (t_p < tabl[MainWindow.word.Length - 4])
                    {
                        r++;
                    }
                }
            }
            double P = r / (1.0 * S1.Count * S2.Count);
            StatisticsBlock.Content = P;
            int N_0 = Convert.ToInt32(CountProtection.Text);
            if(User.IsChecked == false)
            {
                double N = (1 - P) / N_0;
                P1Field.Content = N;
            }
            else
            {
                double N = (1 - P) / N_0;
                P2Field.Content = N;
            }
        }
    }
}

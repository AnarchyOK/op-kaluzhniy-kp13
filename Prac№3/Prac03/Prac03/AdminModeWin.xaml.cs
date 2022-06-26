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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Prac03
{
    /// <summary>
    /// Логика взаимодействия для AdminModeWin.xaml
    /// </summary>
    public partial class AdminModeWin : Window
    {
        MainWindow MainWin;

        String conS = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter Data;
        int num;
        bool WinOpened = false;

        public AdminModeWin(MainWindow mw)
        {
            InitializeComponent();
            conS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MainWin = mw;
        }

        public bool CheckPassword()
        {
            String strQ = "select * from Users where " + "Login = '" + LoginTB.Text + "' and Password = '" + PasswordTB.Text + "';";
            try
            {
                connection = new SqlConnection(conS);
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                if(Table.Rows[0][0].ToString() != null && Table.Rows[0][1].ToString() != null)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(!WinOpened)
                MainWin.Show();
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTB.Text.Replace(" ", "") != "" && PasswordTB.Text.Replace(" ", "") != "")
                LogInBtn.IsEnabled = true;
            else
                LogInBtn.IsEnabled = false;
        }

        public bool CheckIfAdmin()
        {
            string SQLQuery = "select (IsAdmin) from Administrators where " + "UserLogin = '" + LoginTB.Text + "';";
            try
            {
                connection = new SqlConnection(conS);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                if (Table.Rows[0][0].ToString() == "True")
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if(num == 5)
            {
                this.Close();
                MainWin.Show();
            }
            if (CheckPassword())
            {
                if (CheckIfAdmin())
                {
                    AdminToolsWin AdminConsoleWin = new AdminToolsWin(MainWin,LoginTB.Text,PasswordTB.Text);
                    AdminConsoleWin.Show();
                    WinOpened = true;
                    Close();
                }
                else
                {
                    num++;
                    MessageBox.Show("Ви не адміністратор");
                }
            }
            else
            {
                num++;
                MessageBox.Show("Логін або пароль неправильний");
            }
        }
    }
}

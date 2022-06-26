using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Логика взаимодействия для UserModeWin.xaml
    /// </summary>
    public partial class UserModeWin : Window
    {
        MainWindow MainWin;

        bool WinOpened = false;
        string ConnS = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter Data;
        string login;
        string password;
        int num = 0;
        public UserModeWin(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
            ConnS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTB.Text.Replace(" ", "") != "")
                LogInBtn.IsEnabled = true;
            else LogInBtn.IsEnabled = false;
        }

        private bool CheckInfo()
        {
            string strQ = "select Login, Password from Users " + "where Login = '" + LoginTB.Text + "';";

            try
            {
                connection = new SqlConnection(ConnS);
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                if (Table.Rows[0][0].ToString() == LoginTB.Text && Table.Rows[0][1].ToString() == PasswordTB.Text)
                {
                    login = LoginTB.Text;
                    password = PasswordTB.Text;
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch
            {
                
            }
            return false;
        }
        private bool CheckIfBlocked()
        {
            string strQ = "select IsBlocked from Users where " +  "Login = '" + LoginTB.Text + "';";
            try
            {
                connection = new SqlConnection(ConnS);
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                if (Table.Rows[0][0].ToString() == "True")
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch 
            {
               
            }
            return false;
        }
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (num == 3)
            {
                this.Close();
                MainWin.Show();
            }
            if (CheckIfBlocked() == false)
            {
                if (CheckInfo())
                {
                    WinOpened = true;
                    UserToolsWin UserWindow = new UserToolsWin(MainWin, login, password);
                    UserWindow.Show();
                    this.Close();
                }
                else
                {
                    num++;
                    MessageBox.Show("Неправильний логін або пароль");
                }
            }
            else
            {
                MessageBox.Show("Користувача заблоковано");
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!WinOpened)
                MainWin.Show();
        }
    }
}

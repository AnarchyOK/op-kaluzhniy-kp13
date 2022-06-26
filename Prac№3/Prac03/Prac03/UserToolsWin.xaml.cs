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
    /// Логика взаимодействия для UserToolsWin.xaml
    /// </summary>
    /// string connectionString = null;
    public partial class UserToolsWin : Window
    {
        MainWindow MainWin;

        string ConnS = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter Data;
        string CustAllow;
        string login;
        string password;
        public UserToolsWin(MainWindow mw, string login, string password)
        {
            this.login = login;
            this.password = password;
            MainWin = mw;
            InitializeComponent();
            ConnS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            CheckAllowance();
        }

        private void CheckAllowance()
        {
            string strQ = "select IsCustomPasswordEnabled from Users where " + "Login = '" + login + "';";

            try
            {
                connection = new SqlConnection(ConnS);
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                CustAllow = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWin.Show();
        }

        private void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewPassTB.Text.Replace(" ", "") != "" && RepeatNewPassTB.Text.Replace(" ", "") != "")
                ChangePassBtn.IsEnabled = true;
            else ChangePassBtn.IsEnabled = false;
        }

        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
            string updatedPassword = NewPassTB.Text;
            if(CustAllow == "False")
            {
                string allowedChars = "qwertyuiopasdfghjklzxcvbnm1234567890_";
                string newPassword = "";
                string textboxPass = NewPassTB.Text;
                textboxPass = textboxPass.ToLower();
                bool check = false;
                for (int i = 0; i < textboxPass.Length - 1; i++)
                {
                    check = false;
                    for (int j = 0; j < allowedChars.Length - 1; j++)
                    {
                        if (textboxPass[i] == allowedChars[j])
                        {
                            newPassword += NewPassTB.Text[i];
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        MessageBox.Show("Використовуйте символи кирилиці, цифри та нижнє підчеркування");
                        return;
                    }
                }
                updatedPassword = newPassword;
            }
            

            if (OldPassTB.Text == password)
            {
                if (NewPassTB.Text == RepeatNewPassTB.Text)
                {
                    string strQ = "update Users " +   "set Password = '" + updatedPassword + "' " +     "where Login = '" + login + "';";
                    try
                    {
                        connection.Open();
                        command = new SqlCommand(strQ, connection);
                        Data = new SqlDataAdapter(command);
                        DataTable Table = new DataTable();
                        Data.Fill(Table);
                        connection.Close();
                        password = updatedPassword;
                        OldPassTB.Text = "";
                        NewPassTB.Text = "";
                        RepeatNewPassTB.Text = "";
                        ChangePassBtn.IsEnabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Новий пароль не підходить");
                }
            }
            else
            {
                MessageBox.Show("Неправильний пароль");
            }
        }
    }
}

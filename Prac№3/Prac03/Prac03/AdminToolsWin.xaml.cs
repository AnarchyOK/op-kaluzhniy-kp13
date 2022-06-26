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
    /// Логика взаимодействия для AdminToolsWin.xaml
    /// </summary>
    public partial class AdminToolsWin : Window
    {
        MainWindow MainWin;

        string ConnS = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter Data;
        string Login;
        string Password;
        string NewUserLogin;
        public AdminToolsWin(MainWindow mw, string login, string password)
        {
            InitializeComponent();
            MainWin = mw;
            ConnS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(ConnS);
            Login = login;
            Password = password;
            ShowUsersData();
        }
        
        private void ShowUsersData()
        {
            string stqQ = "";
            stqQ += "select Login,Password,IsBlocked,IsCustomPasswordEnabled from Users ";
            stqQ += "left join Administrators on Login = UserLogin " + "where IsAdmin is null;";

            try
            {
                connection.Open();
                command = new SqlCommand(stqQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                UsersDG.ItemsSource = Table.DefaultView;
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
            if (OldPassTB.Text.Replace(" ", "") != "" && NewPassTB.Text.Replace(" ", "") != "" && RepeatNewPassTB.Text.Replace(" ", "") != "")
                ChangePassBtn.IsEnabled = true;
            else ChangePassBtn.IsEnabled = false;
        }
        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
                if (OldPassTB.Text == Password)
                {
                    if (NewPassTB.Text == RepeatNewPassTB.Text)
                    {
                        string strQ = "update Users " + "set Password = '" + NewPassTB.Text + "' " +  "where Login = '" + Login + "';";
                        try
                        {
                            connection.Open();
                            command = new SqlCommand(strQ, connection);
                        Data = new SqlDataAdapter(command);
                            DataTable Table = new DataTable();
                        Data.Fill(Table);
                            connection.Close();

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

        private void UsersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(UsersDG.SelectedItem != null)
            {
                DataRowView Data = null;
                string block = null;
                string allow = null;
                try
                {
                    Data = (DataRowView)UsersDG.SelectedItem;
                    block = Data.Row.ItemArray[2].ToString();
                    allow = Data.Row.ItemArray[3].ToString();
                    NewUserLogin = Data.Row.ItemArray[0].ToString();
                    if (block == "False")
                        BlockCB.IsChecked = false;
                    else BlockCB.IsChecked = true;

                    if (allow == "False")
                        CustomPassCB.IsChecked = false;
                    else CustomPassCB.IsChecked = true;
                }
                catch
                {

                }

            }
        }

        private void BlockCB_Click(object sender, RoutedEventArgs e)
        {
            int block;

            if (BlockCB.IsChecked == true)
                block = 1;
            else block = 0;

            string strQ = "update Users " +  "set IsBlocked = " + block + " " +  "where Login = '" + NewUserLogin + "';";
            try
            {
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                connection.Close();

                ShowUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomPassCB_Click(object sender, RoutedEventArgs e)
        {
            int isTrue;

            if (CustomPassCB.IsChecked == true)
                isTrue = 1;
            else isTrue = 0;

            string strQ = "update Users " + "set IsCustomPasswordEnabled = " + isTrue + " " +  "where Login = '" + NewUserLogin + "';";
            try
            {
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                connection.Close();

                ShowUsersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(LoginTB.Text.Replace(" ","") != "")
                AddUserBtn.IsEnabled = true;
            else AddUserBtn.IsEnabled = false;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            
            AddUserBtn.IsEnabled = false;
            string strQ = "insert into Users ([Login],IsBlocked,IsCustomPasswordEnabled) " + "values ('" + LoginTB.Text + "',0,0);";
            LoginTB.Text = "";

            try
            {
                connection.Open();
                command = new SqlCommand(strQ, connection);
                Data = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                Data.Fill(Table);
                connection.Close();

                ShowUsersData();
                
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}

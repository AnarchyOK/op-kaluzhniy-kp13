using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для EditActors.xaml
    /// </summary>
    public partial class EditActors : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        SqlDataAdapter Data;
        SqlCommand SqlCom;
        DataTable dT;
        String strQ;
        SqlConnection sqlConn;
        string LastIndex;

        public EditActors()
        {
            InitializeComponent();
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            String Name, SurName;
            Data = new SqlDataAdapter("SELECT * FROM InfoAboutActors", sqlConn);
            dT = new DataTable("InfoAboutActors");
            Data.Fill(dT);
            if (dT.Rows.Count > 0)
            {
                LastIndex = (1 + Convert.ToInt32(dT.Rows[dT.Rows.Count - 1][0])).ToString();
            }
            else
            {
                LastIndex = "1";
            }


            Name = TName.Text;
            SurName = TSurname.Text;
            strQ = "";
            strQ += "INSERT INTO InfoAboutActors (ID_Actor, Actor_Name, Actor_Surname) ";
            strQ += "values('" + LastIndex + "','" + Name + "','" + SurName + "');";
            SqlCom = new SqlCommand(strQ, sqlConn);
            MessageBox.Show(SqlCom.ExecuteNonQuery().ToString());
            sqlConn.Close();
            UpgradeTable(sender, e);

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();


            try
            {
                String ID;
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutActors", sqlConn);
                dT = new DataTable("InfoAboutActors");
                Data.Fill(dT);

                ID = ID_n.Text;
                strQ = "DELETE FROM InfoAboutActors WHERE ID_Actor = '" + ID + "';";

                SqlCom = new SqlCommand(strQ, sqlConn);
                MessageBox.Show(SqlCom.ExecuteNonQuery().ToString());
                sqlConn.Close();
                UpgradeTable(sender, e);
            }
            catch { }

        }

       

        private void UpgradeTable(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

           
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutActors", sqlConn);
                dT = new DataTable("InfoAboutActors");
                Data.Fill(dT);
                DataGrid1.ItemsSource = dT.DefaultView;
                sqlConn.Close();
            
        }

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }
        private void IDField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Mouse_Down_grid(object sender, MouseButtonEventArgs e)
        {
            UpgradeTable(sender, e);
        }
    }
}

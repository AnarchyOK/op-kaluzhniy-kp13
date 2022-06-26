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
    /// Логика взаимодействия для EditProdAndOperator.xaml
    /// </summary>
    public partial class EditProdAndOperator : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        SqlDataAdapter Data;
        SqlCommand Com;
        SqlConnection sqlConn;
        DataTable dT;
        String strQ;
        public EditProdAndOperator()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String LastID, Name, Surname, Name2, Surname2;
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutProducers", sqlConn);
                dT = new DataTable("InfoAboutProducers");
                Data.Fill(dT);
                if (dT.Rows.Count > 0)
                    LastID = (1 + Convert.ToInt32(dT.Rows[dT.Rows.Count - 1][0])).ToString();
                else
                    LastID = "1";


                Name = TName.Text;
                Surname = TSurname.Text;
                Name2 = TName2.Text;
                Surname2 = TSurname2.Text;
                strQ = "";
                strQ += "INSERT INTO InfoAboutProducers (ID_Producer, Produser_Name, Produser_Surname, Operator_Name, Operator_Surname) ";
                strQ += "values('" + LastID + "','" + Name + "','" + Surname + "','" + Name2 + "','" + Surname2 + "');";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
                sqlConn.Close();
                UpgradeTable(sender, e);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                try
                {
                    String ID;
                    Data = new SqlDataAdapter("SELECT * FROM InfoAboutProducers", sqlConn);
                    dT = new DataTable("InfoAboutProducers");
                    Data.Fill(dT);

                    ID = IDField.Text;
                    strQ = "DELETE FROM InfoAboutProducers WHERE ID_Producer = '" + ID + "';";

                    Com = new SqlCommand(strQ, sqlConn);

                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                    sqlConn.Close();
                    UpgradeTable(sender, e);
                }
                catch { }
            }
        }

        private void IDField_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void UpgradeTable(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            Data = new SqlDataAdapter("SELECT * FROM InfoAboutProducers", sqlConn);
            dT = new DataTable("InfoAboutProducers");
            Data.Fill(dT);
            DataGrid1.ItemsSource = dT.DefaultView;
            sqlConn.Close();



        }

        private void DataGrid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpgradeTable(sender, e);
        }

       


    }

}

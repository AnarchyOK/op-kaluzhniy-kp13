using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для EditCinemas.xaml
    /// </summary>
    public partial class EditCinemas : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        private static SqlDataAdapter Data;
        private static SqlCommand Com;
        private SqlConnection sqlConn;

        DataTable dT;
        String IDdistrict = "1";
        String strQ;
        public EditCinemas()
        {
            InitializeComponent();
            District.ItemsSource = GetItems();
            District.SelectedIndex = 0;
        }
        private String[] GetItems()
        {
            String[] Items = { "" };

            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoCinemasDistrict", sqlConn);
                dT = new DataTable("InfoCinemasDistrict");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + " " + dT.Rows[i][1].ToString();
                }
            }

            return Items;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }

        private void DataGrid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpgradeTable(sender, e);
        }


        private void UpgradeTable(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutCinemas", sqlConn);

                dT = new DataTable("InfoAboutCinemas");
                Data.Fill(dT);

                DataGrid1.ItemsSource = dT.DefaultView;
                sqlConn.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String LastID, Name, City, Seats;
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutCinemas", sqlConn);
                dT = new DataTable("InfoAboutCinemas");
                Data.Fill(dT);
                if (dT.Rows.Count > 0)
                    LastID = (1 + Convert.ToInt32(dT.Rows[dT.Rows.Count - 1][0])).ToString();
                else
                    LastID = "1";

                Name = TName.Text;
                City = TCity.Text;
                Seats = TSeats.Text;
                strQ = "";
                strQ += "INSERT INTO InfoAboutCinemas (ID_Cinema, Cinema_Name, City, ID_district, Number_Of_Seats) ";
                strQ += "values('" + LastID + "','" + Name + "','" + City + "','" + IDdistrict + "','" + Seats + "');";
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
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    String ID;
                    Data = new SqlDataAdapter("SELECT * FROM InfoAboutCinemas", sqlConn);
                    dT = new DataTable("InfoAboutCinemas");
                    Data.Fill(dT);
                    ID = IDField.Text;
                    strQ = "DELETE FROM InfoAboutCinemas WHERE ID_Cinema = '" + ID + "';";
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                    sqlConn.Close();
                    UpgradeTable(sender, e);
                }
                catch { }
            }

        }

        private void District_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String Text = District.SelectedItem.ToString();
            for (int i = 0; i < dT.Rows.Count; i++)
            {
                String tempStr = dT.Rows[i][0].ToString() + " " + dT.Rows[i][1].ToString();
                if (Text == tempStr)
                    IDdistrict = dT.Rows[i][0].ToString();
            }
        }


    }
}

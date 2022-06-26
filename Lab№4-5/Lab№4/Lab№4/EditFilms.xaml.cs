using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab4
{

    /// <summary>
    /// Логика взаимодействия для EditFilms.xaml
    /// </summary>
    public partial class EditFilms : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        SqlDataAdapter Data;
        SqlCommand Com, ComAddImage;
        SqlConnection sqlConn;
        OpenFileDialog dialog;
        DataTable dT;
        String strQ, ImageWay = "";

        public EditFilms()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }

        private void UpgradeTable(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutFilms", sqlConn);

                dT = new DataTable("InfoAboutFilms");
                Data.Fill(dT);

                DataGrid1.ItemsSource = dT.DefaultView;
                sqlConn.Close();
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
                    Data = new SqlDataAdapter("SELECT * FROM InfoAboutFilms", sqlConn);
                    dT = new DataTable("InfoAboutFilms");
                    Data.Fill(dT);

                    ID = IDField.Text;
                    strQ = "DELETE FROM InfoAboutFilms WHERE ID_Film = '" + ID + "';";

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String lastID, Name, Name2;
                String year, reward, rating;
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutFilms", sqlConn);
                dT = new DataTable("InfoAboutFilms");
                Data.Fill(dT);
                if (dT.Rows.Count > 0)
                    lastID = (1 + Convert.ToInt32(dT.Rows[dT.Rows.Count - 1][0])).ToString();
                else
                    lastID = "1";
                Name = Field_Name.Text;
                Name2 = Field_OriginalName.Text;
                year = Field_Year.Text;
                reward = RewardCheckek.IsChecked.ToString();
                rating = Field_Rating.Text;

                strQ = "";
                strQ += "INSERT INTO InfoAboutFilms (ID_Film, Film_Name, Original_Name, Year, Rating, Reward) ";
                strQ += "values('" + lastID + "','" + Name + "','" + Name2 + "','" + year + "','" + rating + "','" + reward + "')";
                Com = new SqlCommand(strQ, sqlConn);
                MessageBox.Show(Com.ExecuteNonQuery().ToString());
                if (ImageWay != "")
                {
                    strQ = "UPDATE InfoAboutFilms SET Title = (SELECT * FROM OPENROWSET(BULK '" + @ImageWay + "', SINGLE_BLOB) AS image) WHERE ID_Film = " + @lastID + ";";
                    MessageBox.Show(strQ);
                    ComAddImage = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(ComAddImage.ExecuteNonQuery().ToString());
                }
                sqlConn.Close();
                UpgradeTable(sender, e);
            }
        }



        private void ImageCinema_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dialog = new OpenFileDialog();

            dialog.Title = "Select a picture";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (dialog.ShowDialog() == true)
            {
                ImageSource.Source = new BitmapImage(new Uri(dialog.FileName));
                ImageWay = dialog.FileName;
            }
        }


       

        private void DataGrid1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpgradeTable(sender, e);
        }
    }
}

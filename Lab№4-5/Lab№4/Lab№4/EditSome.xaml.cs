using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для EditSome.xaml
    /// </summary>
    public partial class EditSome : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        SqlDataAdapter Data;
        SqlCommand Com;
        SqlConnection sqlConn;
        DataTable dT, dT1, dT2, dT3, dT4, dT5;
        String strQ;

        public EditSome()
        {
            InitializeComponent();
            TI.ItemsSource = GetItemsCinemas(); TI.SelectedIndex = 0;
            TI2.ItemsSource = GetItemsCinemas(); TI2.SelectedIndex = 0;
            GI.ItemsSource = GetItemsGenres(); GI.SelectedIndex = 0;
            AI.ItemsSource = GetItemsActors(); AI.SelectedIndex = 0;

            FI.ItemsSource = GetItemsFilms(); FI.SelectedIndex = 0;
            FI2.ItemsSource = GetItemsFilms(); FI2.SelectedIndex = 0;
            FI3.ItemsSource = GetItemsFilms(); FI3.SelectedIndex = 0;
            FI4.ItemsSource = GetItemsFilms(); FI4.SelectedIndex = 0;
            PI.ItemsSource = GetItemsProducers(); PI.SelectedIndex = 0;
            TC.ItemsSource = GetItemsTicketsCost(); TC.SelectedIndex = 0;

            UpgradeTableFilmActors();
            UpgradeTableFilmGenre();
            UpgradeTableFilmProducer();
            UpgradeTableFilmsToCinemas();
            UpgradeTableTickets();
        }
        private String[] GetItemsCinemas()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutCinemas", sqlConn);
                dT = new DataTable("InfoAboutCinemas");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + ". " + dT.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }
        private String[] GetItemsProducers()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutProducers", sqlConn);
                dT = new DataTable("InfoAboutProducers");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + ". " + dT.Rows[i][1].ToString() + " " + dT.Rows[i][2].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }
        private String[] GetItemsGenres()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutGenres", sqlConn);
                dT = new DataTable("InfoAboutGenres");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + ". " + dT.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }
        private String[] GetItemsActors()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutActors", sqlConn);
                dT = new DataTable("InfoAboutActors");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + ". " + dT.Rows[i][1].ToString() + " " + dT.Rows[i][2].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }
        private String[] GetItemsFilms()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutFilms", sqlConn);
                dT = new DataTable("InfoAboutFilms");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString() + ". " + dT.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }
        private String[] GetItemsTicketsCost()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM FilmsToCinemas", sqlConn);
                dT = new DataTable("FilmsToCinemas");
                Data.Fill(dT);

                Items = new String[dT.Rows.Count];
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    Items[i] = dT.Rows[i][0].ToString();
                }
            }
            sqlConn.Close();

            return Items;
        }

        private void ToStartWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }


        private String GetLinkID(String TableName, String ColumnName, Int32 index)
        {
            String ID = "1";

            String Sq = "SELECT " + ColumnName + " FROM " + TableName;
            Data = new SqlDataAdapter(Sq, sqlConn);
            dT = new DataTable("ColumnData");
            Data.Fill(dT);
            ID = dT.Rows[index][0].ToString();

            return ID;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutActors", "ID_Actor", AI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI.SelectedIndex);
                strQ = "INSERT INTO ActorsToFilms (ID_Actor, ID_Film) values(" + ID_1 + ", " + ID_2 + ");";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmActors();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutActors", "ID_Actor", AI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI.SelectedIndex);
                strQ = "DELETE FROM ActorsToFilms WHERE ID_Actor = " + ID_1 + " AND ID_Film = " + ID_2 + ";";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmActors();
        }

        private void AddBtn2_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutGenres", "ID_Genre", GI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI2.SelectedIndex);
                strQ = "INSERT INTO FilmsToGenre (ID_Genre, ID_Film) values(" + ID_1 + ", " + ID_2 + ");";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmGenre();
        }

        private void RemoveBtn2_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutGenres", "ID_Genre", GI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI2.SelectedIndex);
                strQ = "DELETE FROM FilmsToGenre WHERE ID_Genre = " + ID_1 + " AND ID_Film = " + ID_2 + ";";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmGenre();
        }



        private void AddBtn3_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == ConnectionState.Open)
            {
                String lastID, ID_f, ID_t, Data, stTime, fnTime, cost;

                SqlDataAdapter DTable = new SqlDataAdapter("SELECT * FROM FilmsToCinemas", sqlConn);
                dT = new DataTable("FilmsToCinemas");
                DTable.Fill(dT);
                if (dT.Rows.Count > 0)
                    lastID = (1 + Convert.ToInt32(dT.Rows[dT.Rows.Count - 1][0])).ToString();
                else
                    lastID = "1";
                ID_f = GetLinkID("InfoAboutFilms", "ID_Film", FI3.SelectedIndex);
                ID_t = GetLinkID("InfoAboutCinemas", "ID_Cinema", TI.SelectedIndex);
                Data = DataLabel.Content.ToString();
                stTime = startTimeFileld.Text;
                fnTime = finishTimeFileld.Text;
                cost = costField.Text;
                try
                {
                    strQ = "";
                    strQ += "INSERT INTO FilmsToCinemas (ID_FilmCost, ID_Film, InfoAboutFilms, Data, Time_Of_Start, Time_Of_Finish, Cost) ";
                    strQ += "values('" + lastID + "', '" + ID_f + "', '" + ID_t + "', '" + Data + "', '" + stTime + "', '" + fnTime + "', '" + cost + "');";
                    Com = new SqlCommand(strQ, sqlConn);

                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                }
                catch
                {
                    MessageBox.Show("Неправильні дані!");
                }
            }
            sqlConn.Close();
            UpgradeTableFilmsToCinemas();
            TC.ItemsSource = GetItemsTicketsCost();
        }

        private void RemoveBtn3_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == ConnectionState.Open)
            {
                String ID = IDField.Text;

                try
                {
                    strQ = "DELETE FROM FilmsToCinemas WHERE ID_FilmCost = '" + ID + "';";
                    Com = new SqlCommand(strQ, sqlConn);
                    MessageBox.Show(Com.ExecuteNonQuery().ToString());
                }
                catch { }
            }
            sqlConn.Close();

            UpgradeTableFilmsToCinemas();
            TC.ItemsSource = GetItemsTicketsCost();
        }


        private void AddBtn4_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutProducers", "ID_Producer", PI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI4.SelectedIndex);
                strQ = "INSERT INTO ProducersToFilms (ID_Producer, ID_Film) values(" + ID_1 + ", " + ID_2 + ");";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmProducer();
        }

        private void RemoveBtn4_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutProducers", "ID_Producer", PI.SelectedIndex);
                ID_2 = GetLinkID("InfoAboutFilms", "ID_Film", FI4.SelectedIndex);
                strQ = "DELETE FROM ProducersToFilms WHERE ID_Producer = " + ID_1 + " AND ID_Film = " + ID_2 + ";";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableFilmProducer();
        }

        private void AddBtn5_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutCinemas", "ID_Cinema", TI2.SelectedIndex);
                ID_2 = GetLinkID("FilmsToCinemas", "ID_FilmCost", TC.SelectedIndex);
                strQ = "INSERT INTO TicketsCost (ID_Cinema, ID_Film_Cost) values(" + ID_1 + ", " + ID_2 + ");";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableTickets();
        }

        private void RemoveBtn5_Click(object sender, RoutedEventArgs e)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            if (sqlConn.State == ConnectionState.Open)
            {
                String ID_1, ID_2;

                ID_1 = GetLinkID("InfoAboutCinemas", "ID_Cinema", TI2.SelectedIndex);
                ID_2 = GetLinkID("FilmsToCinemas", "ID_FilmCost", TC.SelectedIndex);
                MessageBox.Show(ID_1 + " " + ID_2);
                strQ = "DELETE FROM TicketsCost WHERE ID_Cinema = " + ID_1 + " AND ID_Film_Cost = " + ID_2 + ";";
                Com = new SqlCommand(strQ, sqlConn);

                MessageBox.Show(Com.ExecuteNonQuery().ToString());
            }
            sqlConn.Close();
            UpgradeTableTickets();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpgradeTableFilmActors();
        }
        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpgradeTableFilmGenre();
        }
        private void DataGrid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpgradeTableFilmsToCinemas();
        }
        private void DataGrid4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpgradeTableFilmProducer();
        }
        private void DataGrid5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpgradeTableTickets();
        }

        private void UpgradeTableFilmActors()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            strQ = "";
            strQ += "SELECT Film_Name, Actor_Name, Actor_Surname  FROM InfoAboutFilms, InfoAboutActors, ActorsToFilms ";
            strQ += "WHERE InfoAboutFilms.ID_Film = ActorsToFilms.ID_Film AND InfoAboutActors.ID_Actor = ActorsToFilms.ID_Actor ";
            strQ += "GROUP BY Film_Name, Actor_Name, Actor_Surname;";

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT1 = new DataTable("InfoAboutCinemas");
                Data.Fill(dT1);

                Com = new SqlCommand(strQ, sqlConn);
                DataGrid1.ItemsSource = dT1.DefaultView;
                sqlConn.Close();
            }
        }
        private void UpgradeTableTickets()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            strQ = "";
            strQ += "SELECT ID_Film_Cost, Cinema_Name FROM InfoAboutCinemas, TicketsCost ";
            strQ += "WHERE InfoAboutCinemas.ID_Cinema = TicketsCost.ID_Cinema ";
            strQ += "GROUP BY ID_Film_Cost, Cinema_Name;";

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT5 = new DataTable("TicketsCost");
                Data.Fill(dT5);

                Com = new SqlCommand(strQ, sqlConn);
                DataGrid5.ItemsSource = dT5.DefaultView;
                sqlConn.Close();
            }
        }
        private void UpgradeTableFilmGenre()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            strQ = "";
            strQ += "SELECT Film_Name, Name_Of_Genre FROM InfoAboutFilms, FilmsToGenre, InfoAboutGenres ";
            strQ += "WHERE FilmsToGenre.ID_Genre = InfoAboutGenres.ID_Genre ";
            strQ += "GROUP BY Film_Name, Name_Of_Genre;";

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT2 = new DataTable("FilmsToGenre");
                Data.Fill(dT2);

                Com = new SqlCommand(strQ, sqlConn);
                DataGrid2.ItemsSource = dT2.DefaultView;
                sqlConn.Close();
            }
        }
        private void UpgradeTableFilmProducer()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            strQ = "";
            strQ += "SELECT Film_Name, Produser_Name, Produser_Surname FROM InfoAboutFilms, ProducersToFilms, InfoAboutProducers ";
            strQ += "WHERE ProducersToFilms.ID_Film = InfoAboutFilms.ID_Film AND InfoAboutProducers.ID_Producer = ProducersToFilms.ID_Producer ";
            strQ += "GROUP BY Film_Name, Produser_Name, Produser_Surname;";

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT4 = new DataTable("ProducersToFilms");
                Data.Fill(dT4);

                Com = new SqlCommand(strQ, sqlConn);
                DataGrid4.ItemsSource = dT4.DefaultView;
                sqlConn.Close();
            }
        }
        private void UpgradeTableFilmsToCinemas()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();

            strQ = "";
            strQ += "SELECT ID_FilmCost, Film_Name, Cinema_Name, Data, Time_Of_Start, Time_Of_Finish, Cost FROM InfoAboutFilms, FilmsToCinemas, InfoAboutCinemas ";
            strQ += "WHERE FilmsToCinemas.ID_Film = InfoAboutFilms.ID_Film AND InfoAboutCinemas.ID_Cinema = FilmsToCinemas.ID_Cinema ";
            strQ += "GROUP BY ID_FilmCost, Film_Name, Cinema_Name, Data, Time_Of_Start, Time_Of_Finish, Cost;";

            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter(strQ, sqlConn);
                dT3 = new DataTable("FilmsToCinemas");
                Data.Fill(dT3);

                Com = new SqlCommand(strQ, sqlConn);
                DataGrid3.ItemsSource = dT3.DefaultView;
                sqlConn.Close();
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendar1.SelectedDate.HasValue)
            {
                DateTime date = calendar1.SelectedDate.Value;
                String StrData = date.ToShortDateString();
                DataLabel.Content = StrData;
            }
        }
    }
}

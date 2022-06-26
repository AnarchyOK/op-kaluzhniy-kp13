using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";

        SqlDataAdapter Data;
        SqlConnection sqlConn;

        DataTable dT, dTActors, dTCinemas;
        String strQ;
        public Requests()
        {
            InitializeComponent();
            GetItemsActors();
            GetItemsCinemas();

            Request1(CinemaData);
            Request4(FilmsReward);
            Request6(FilmsData);
            Request7(c100_50);
            Request8(Money);
        }
        private void ToStartWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }

        private void Request1(DataGrid Table)
        {
            strQ = "";
            strQ += "SELECT Cinema_Name[Назва кінотеатру], City[Місто], District_Name[Район] ";
            strQ += "FROM InfoAboutCinemas, InfoCinemasDistrict WHERE ";
            strQ += "InfoAboutCinemas.ID_district = InfoCinemasDistrict.ID_District ";
            strQ += "ORDER BY District_Name;";
            Request(Table, strQ);
        }

        private void Request2(DataGrid Table, String strIndex)
        {
            strQ = "";
            strQ += "SELECT  Film_Name[Назва фільму], Data[Дата], Time_Of_Start[Час початку], ";
            strQ += "Time_Of_Finish[Час закінчення], Actor_Name[Ім'я актора], ";
            strQ += "Actor_Surname[Прізвище Актора] FROM ";
            strQ += "InfoAboutActors, ActorsToFilms, InfoAboutFilms, FilmsToCinemas WHERE ";
            strQ += "InfoAboutActors.ID_Actor = " + strIndex + " ";
            strQ += "AND ActorsToFilms.ID_Actor = InfoAboutActors.ID_Actor AND ";
            strQ += "ActorsToFilms.ID_Film = InfoAboutFilms.ID_Film AND ";
            strQ += "InfoAboutFilms.ID_Film = FilmsToCinemas.ID_Film ";
            strQ += "GROUP BY Actor_Surname, Actor_Name, Film_Name, FilmsToCinemas.Data, Time_Of_Start, Time_Of_Finish ";
            strQ += "ORDER BY Film_Name ";
            Request(Table, strQ);
        }

        private void Request3(DataGrid Table, String strData)
        {
            strQ = "";
            strQ += "SELECT Cinema_Name[Назва кінотеатру], Film_Name[Назва фільму], Data[Дата], Time_Of_Start[Час початку], Time_Of_Finish[Час закінчення], Name_Of_Genre[Назва жанру] ";
            strQ += "FROM InfoAboutFilms, FilmsToCinemas, InfoAboutGenres, InfoAboutCinemas, FilmsToGenre WHERE ";
            strQ += "InfoAboutGenres.Name_Of_Genre = 'Бойовик' AND Data = '" + strData + "' AND ";
            strQ += "InfoAboutGenres.ID_Genre = FilmsToGenre.ID_Genre AND ";
            strQ += "FilmsToGenre.ID_Film = InfoAboutFilms.ID_Film AND ";
            strQ += "InfoAboutCinemas.ID_Cinema = FilmsToCinemas.ID_Cinema ";
            strQ += "GROUP BY Cinema_Name, Name_Of_Genre, Film_Name, Data, Time_Of_Start, Time_Of_Finish ";
            strQ += "ORDER BY Cinema_Name, Film_Name;";
            Request(Table, strQ);
        }

        private void Request4(DataGrid Table)
        {
            strQ = "";
            strQ += "SELECT Film_Name[Назва фільму], Cinema_Name[Назва кінотеатру], Reward[Наявність нагороди] ";
            strQ += "FROM InfoAboutFilms, FilmsToCinemas, InfoAboutCinemas WHERE ";
            strQ += "InfoAboutFilms.Reward = 1 AND FilmsToCinemas.ID_Film = InfoAboutFilms.ID_Film ";
            strQ += "GROUP BY Film_Name, Cinema_Name, Reward ";
            strQ += "ORDER BY Film_Name;";

            Request(Table, strQ);
        }

        private void Request5(DataGrid Table, String stData, String fnData, String IDTheater)
        {
            strQ = "";
            strQ += "SELECT Cinema_Name[Назва кінотеатру], Data[Дата проведення], Film_Name[Назва фільму], Time_Of_Start[Час початку], Time_Of_Finish[Час закінчення], Cost[Вартіст квитка, грн.] ";
            strQ += "FROM InfoAboutCinemas, InfoAboutFilms, FilmsToCinemas WHERE ";
            strQ += "InfoAboutCinemas.ID_Cinema = FilmsToCinemas.ID_Cinema AND ";
            strQ += "InfoAboutFilms.ID_Film = FilmsToCinemas.ID_Film AND ";
            strQ += "FilmsToCinemas.Data BETWEEN '" + stData + "' AND '" + fnData + "' AND ";
            strQ += "InfoAboutCinemas.ID_Cinema = " + IDTheater + " ";
            strQ += "ORDER by Data;";

            Request(Table, strQ);
        }

        private void Request6(DataGrid Table)
        {
            strQ = "SELECT TOP(100) PERCENT dbo.InfoCinemasDistrict.District_Name AS[Назва району], dbo.InfoAboutCinemas.Cinema_Name AS[Назва театру], dbo.InfoAboutFilms.Film_Name AS[Назва фільму], dbo.FilmsToCinemas.Data AS Дата ";
            strQ += "FROM dbo.InfoCinemasDistrict INNER JOIN ";
            strQ += "dbo.InfoAboutCinemas ON dbo.InfoCinemasDistrict.ID_District = ";
            strQ += "dbo.InfoAboutCinemas.ID_district INNER JOIN ";
            strQ += "dbo.FilmsToCinemas ON dbo.InfoAboutCinemas.ID_Cinema = ";
            strQ += "dbo.FilmsToCinemas.ID_Cinema INNER JOIN ";
            strQ += "dbo.InfoAboutFilms ON dbo.FilmsToCinemas.ID_Film = ";
            strQ += "dbo.InfoAboutFilms.ID_Film;";

            Request(Table, strQ);
        }
          private void Request8(DataGrid Table)
        {
            strQ = "SELECT dbo.InfoAboutCinemas.Cinema_Name AS [Назва кінотеатру], ";
            strQ += "SUM(dbo.FilmsToCinemas.Cost) AS Прибуток ";
            strQ += "FROM dbo.InfoAboutCinemas INNER JOIN ";
            strQ += "dbo.TicketsCost ON dbo.InfoAboutCinemas.ID_Cinema = ";
            strQ += "dbo.TicketsCost.ID_Cinema INNER JOIN ";
            strQ += "dbo.FilmsToCinemas ON dbo.InfoAboutCinemas.ID_Cinema = ";
            strQ += "dbo.FilmsToCinemas.ID_Cinema ";
            strQ += "GROUP BY dbo.InfoAboutCinemas.Cinema_Name;";

            Request(Table, strQ);
        }


        private void Request7(DataGrid Table)
        {
            strQ = "SELECT dbo.InfoAboutCinemas.Cinema_Name AS [Назва театру], dbo.InfoAboutFilms.Film_Name AS [Назва фільму], dbo.FilmsToCinemas.Cost AS [Вартість квитка] ";
            strQ += "FROM dbo.InfoAboutFilms INNER JOIN ";
            strQ += "dbo.FilmsToCinemas ON dbo.InfoAboutFilms.ID_Film = ";
            strQ += "dbo.FilmsToCinemas.ID_Film INNER JOIN ";
            strQ += "dbo.InfoAboutCinemas ON dbo.FilmsToCinemas.ID_Cinema = ";
            strQ += "dbo.InfoAboutCinemas.ID_Cinema INNER JOIN ";
            strQ += "dbo.TicketsCost ON dbo.InfoAboutCinemas.ID_Cinema = ";
            strQ += "dbo.TicketsCost.ID_Cinema ";
            strQ += "WHERE(dbo.FilmsToCinemas.Cost < 100) AND (dbo.FilmsToCinemas.Cost > 50);";

            Request(Table, strQ);
        }


      


        private void GetItemsActors()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutActors", sqlConn);
                dTActors = new DataTable("InfoAboutActors");
                Data.Fill(dTActors);

                Items = new String[dTActors.Rows.Count];
                for (int i = 0; i < dTActors.Rows.Count; i++)
                {
                    Items[i] = dTActors.Rows[i][0].ToString() + ". " + dTActors.Rows[i][1].ToString() + " " + dTActors.Rows[i][2].ToString();
                }
            }
            sqlConn.Close();
            ActorsCBox.ItemsSource = Items;
            ActorsCBox.SelectedIndex = 0;
        }

        private void GetItemsCinemas()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String[] Items = { "" };
            if (sqlConn.State == ConnectionState.Open)
            {
                Data = new SqlDataAdapter("SELECT * FROM InfoAboutCinemas", sqlConn);
                dTCinemas = new DataTable("InfoAboutCinemas");
                Data.Fill(dTCinemas);

                Items = new String[dTCinemas.Rows.Count];
                for (int i = 0; i < dTCinemas.Rows.Count; i++)
                {
                    Items[i] = dTCinemas.Rows[i][0].ToString() + ". " + dTCinemas.Rows[i][1].ToString();
                }
            }
            sqlConn.Close();
            TheatersCBox.ItemsSource = Items;
            TheatersCBox.SelectedIndex = 0;
        }


        private void Go3_Click(object sender, RoutedEventArgs e)
        {
            DateTime SDate;
            try
            {
                SDate = dp.SelectedDate.Value;
                Request3(ComediesData, SDate.ToShortDateString());
            }
            catch
            {
                MessageBox.Show("Неправильна дата!!!");
            }
        }

        private void Go2_Click(object sender, SelectionChangedEventArgs e)
        {
            Int32 i = ActorsCBox.SelectedIndex;
            Request2(Theater_P_Actor, dTActors.Rows[i][0].ToString());
        }

        private void Go5_Click(object sender, RoutedEventArgs e)
        {
            DateTime prev, last;
            Int32 index = TheatersCBox.SelectedIndex;
            try
            {
                prev = PData.SelectedDate.Value;
                last = LData.SelectedDate.Value;

                Request5(CostData, PData.SelectedDate.Value.ToShortDateString(), LData.SelectedDate.Value.ToShortDateString(), dTCinemas.Rows[index][0].ToString());
            }
            catch
            {
                MessageBox.Show("Неправильна дата!!!");
            }
        }

        private void Request(DataGrid Table, string Str)
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            Data = new SqlDataAdapter(Str, sqlConn);
            dT = new DataTable();
            Data.Fill(dT);
            Table.ItemsSource = dT.DefaultView;
            sqlConn.Close();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Afisha.xaml
    /// </summary>
    public partial class Afisha : Window
    {
        private static String Connection = @"Data Source=ALEXPC;Initial Catalog=Info_Cinemas;Integrated Security=True";
        Int32 i = 0;
        Int32 Lenth;
        SqlDataAdapter Data;
        SqlConnection sqlConn;
        DataTable dT, dTProd,dTOper;
        String strQ;
        public Afisha()
        {
            InitializeComponent();
            StartTable();
            GetFilmInfo(i);
            GetProducers(i);
            GetOperators(i);
        }
        

        private void StartTable()
        {
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            strQ = "SELECT * FROM InfoAboutFilms;";
            Data = new SqlDataAdapter(strQ, sqlConn);
            dT = new DataTable("InfoAboutFilms");
            Data.Fill(dT);
            Lenth = dT.Rows.Count;
            sqlConn.Close();
        }

        private String[] GetProducers(Int32 ID_Film)
        {
            String[] StrProd = { " " };

            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            strQ = "";
            strQ += "SELECT Produser_Name, Produser_Surname FROM InfoAboutProducers, ProducersToFilms, InfoAboutFilms ";
            strQ += "WHERE InfoAboutFilms.ID_Film = " + Convert.ToString(ID_Film) + " AND ";
            strQ += "ProducersToFilms.ID_Film = InfoAboutFilms.ID_Film AND ";
            strQ += "ProducersToFilms.ID_Producer = InfoAboutProducers.ID_Producer;";
            Data = new SqlDataAdapter(strQ, sqlConn);
            dTProd = new DataTable("InfoAboutProducers");
            Data.Fill(dTProd);
            StrProd = new string[dTProd.Rows.Count];
            sqlConn.Close();
            for (int i = 0; i < dTProd.Rows.Count; i++)
                StrProd[i] = dTProd.Rows[i][0] + " " + dTProd.Rows[i][1];
            return StrProd;
        }
        private String[] GetOperators(Int32 ID_Film)
        {
            String[] StrProd = { " " };
            sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            strQ = "";
            strQ += "SELECT Operator_Name, Operator_Surname FROM InfoAboutProducers, ProducersToFilms, InfoAboutFilms ";
            strQ += "WHERE InfoAboutFilms.ID_Film = " + Convert.ToString(ID_Film) + " AND ";
            strQ += "ProducersToFilms.ID_Film = InfoAboutFilms.ID_Film AND ";
            strQ += "ProducersToFilms.ID_Producer = InfoAboutProducers.ID_Producer;";
            Data = new SqlDataAdapter(strQ, sqlConn);
            dTOper = new DataTable("InfoAboutProducers");
            Data.Fill(dTOper);
            StrProd = new string[dTOper.Rows.Count];
            sqlConn.Close();
            for (int i = 0; i < dTOper.Rows.Count; i++)
                StrProd[i] = dTOper.Rows[i][0] + " " + dTOper.Rows[i][1];
            return StrProd;
        }

        private void GetFilmInfo(Int32 index)
        {
            String ID_Film = dT.Rows[index][0].ToString();
            IDFilm.Content = ID_Film;
            Name1.Content = dT.Rows[index][1].ToString();
            Name2.Content = dT.Rows[index][2].ToString();
            Year.Content = dT.Rows[index][3].ToString();
            Rating.Content = dT.Rows[index][4].ToString();
            Reward.Content = dT.Rows[index][5].ToString();
            Producer.ItemsSource = GetProducers(Convert.ToInt32(ID_Film));
            Producer.SelectedIndex = 0;
            Operator.ItemsSource = GetOperators(Convert.ToInt32(ID_Film));
            Operator.SelectedIndex = 0;

           /* MemoryStream ms = new MemoryStream((byte[])dT.Rows[index][6]);
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = ms;
            imageSource.EndInit();
            Image.Source = imageSource;*/
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWin mw = new MainWin();
            Hide();
            mw.Show();
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                i--;
                GetFilmInfo(i);
            }

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (i < Lenth - 1)
            {
                i++;
                GetFilmInfo(i);
            }
        }
    }
}

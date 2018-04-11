using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Dal
{
    public static class DALOverzicht
    {
        public static List<Sparta.Model.Cursus> GetCursussen()
        {
            List<Sparta.Model.Cursus> cursussen = new List<Sparta.Model.Cursus>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT CursusId, Naam, Niveau, Toelichting, Categorie FROM Cursus;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sparta.Model.Cursus cursus = LeesCursus(reader);
                cursussen.Add(cursus);
            }

            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return cursussen;
        }

        public static Sparta.Model.Cursus LeesCursus(SqlDataReader reader)
        {
            Sparta.Model.Cursus cursus = new Sparta.Model.Cursus();

            cursus.Id = (int)reader["CursusId"];
            cursus.Naam = (string)reader["Naam"];
            cursus.Niveau = (int)reader["Niveau"];
            cursus.Toelichting = (string)reader["Toelichting"];
            cursus.Categorie = (Model.DeelnemerCategorie)reader["Categorie"];

            return cursus;
        }

        //public struct Cursus
        //{
        //    public int cursusId;
        //    public string naam;
        //    public string niveau;
        //    public string toelichting;
        //    public int categorie;
        //}      


        //----------------------------------------------------------------------------------------------

        //Locaties

        public struct Locatie
        {
            public int locatieId;
            public string gebouw;
            public string zaal;
            public string omschrijving;
        }

        public static List<Locatie> GetLocaties()
        {
            List<Locatie> locatie = new List<Locatie>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT LocatieId,Gebouw,Zaal,Omschrijving FROM Locatie;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Locatie locaties = LeesLocatie(reader);
                locatie.Add(locaties);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return locatie;
        }

        public static Locatie LeesLocatie(SqlDataReader reader)
        {
            Locatie locatie = new Locatie();

            locatie.locatieId = (int)reader["locatieId"];
            locatie.gebouw = (string)reader["gebouw"];
            locatie.zaal = (string)reader["zaal"];
            locatie.omschrijving = (string)reader["omschrijving"];

            return locatie;
        }

        //----------------------------------------------------------------------------------------------
        //personen

        public static List<Persoon> GetPersonen()
        {
            List<Persoon> personen = new List<Persoon>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT PersoonId, Naam, Achternaam, Categorie, GeboorteDatum FROM Persoon;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Persoon persoon = LeesPersoon(reader);
                personen.Add(persoon);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return personen;
        }

        public static Persoon LeesPersoon(SqlDataReader reader)
        {
            Persoon persoon = new Persoon();

            persoon.PersoonId = (int)reader["PersoonId"];
            persoon.Naam = (string)reader["Naam"];
            persoon.Achternaam = (string)reader["Achternaam"];
            persoon.catergorie = (int)reader["Catergorie"];
            persoon.GeboorteDatum = (DateTime)reader["GeboorteDatum"];

            return persoon;
        }

        public struct Persoon
        {
            public int PersoonId;
            public string Naam;
            public string Achternaam;
            public int catergorie;
            public DateTime GeboorteDatum;
        }
    }

}

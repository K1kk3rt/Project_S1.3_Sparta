using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALOverzicht
    {
        public static List<Cursus> GetCursussen()
        {
            List<Cursus> cursussen = new List<Cursus>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT CursusId, Naam, Niveau, Toelichting, Categorie FROM Cursus;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Cursus cursus = LeesCursus(reader);
                cursussen.Add(cursus);
            }

            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return cursussen;
        }

        public static Cursus LeesCursus(SqlDataReader reader)
        {
            Cursus cursus = new Cursus();

            cursus.cursusId = (int)reader["CursusId"];
            cursus.naam = (string)reader["Naam"];
            cursus.niveau = (string)reader["Niveau"];
            cursus.toelichting = (string)reader["Toelichting"];
            cursus.categorie = (int)reader["Categorie"];

            return cursus;
        }

        public struct Cursus
        {
            public int cursusId;
            public string naam;
            public string niveau;
            public string toelichting;
            public int categorie;
        }      


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
                Persoon persoon = new Persoon();

                persoon.PersoonId = (int)reader["PersoonId"];
                persoon.Naam = (string)reader["Naam"];
                persoon.Achternaam = (string)reader["Achternaam"];
                persoon.catergorie = (int)reader["Catergorie"];
                persoon.GeboorteDatum = (DateTime)reader["GeboorteDatum"];

                personen.Add(persoon);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);

            return personen;
        }

        //public static Persoon LeesPersoon(SqlDataReader reader)
        //{
        //    Persoon persoon = new Persoon();

        //    persoon.PersoonId = (int)reader["PersoonId"];
        //    persoon.Naam = (string)reader["Naam"];
        //    persoon.Achternaam = (string)reader["Achternaam"];
        //    persoon.catergorie = (int)reader["Catergorie"];
        //    persoon.GeboorteDatum = (DateTime)reader["GeboorteDatum"];

        //    return persoon;
        //}

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

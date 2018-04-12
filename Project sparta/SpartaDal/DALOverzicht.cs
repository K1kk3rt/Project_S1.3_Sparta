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
        //----------------------------------------------------------------------------------------------

        //Cursussen

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
                Sparta.Model.Cursus cursus = new Sparta.Model.Cursus();

                cursus.Id = (int)reader["CursusId"];
                cursus.Naam = (string)reader["Naam"];
                cursus.Niveau = (int)reader["Niveau"];
                cursus.Toelichting = (string)reader["Toelichting"];
                cursus.Categorie = (Model.DeelnemerCategorie)reader["Categorie"];

                cursussen.Add(cursus);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return cursussen;
        } 


        //----------------------------------------------------------------------------------------------

        //Locaties
               

        public static List<Sparta.Model.Locatie> GetLocaties()
        {
            List<Sparta.Model.Locatie> locaties = new List<Sparta.Model.Locatie>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT LocatieId,Gebouw,Zaal,Omschrijving FROM Locatie;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sparta.Model.Locatie locatie = new Sparta.Model.Locatie();

                locatie.Id = (int)reader["locatieId"];
                locatie.Gebouw = (string)reader["gebouw"];
                locatie.Zaal = (string)reader["zaal"];
                locatie.Omschrijving = (string)reader["omschrijving"];              
                                                             
                locaties.Add(locatie);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return locaties;
        }       

        //----------------------------------------------------------------------------------------------

        //personen

        public static List<Sparta.Model.Persoon> GetPersonen()
        {
            List<Sparta.Model.Persoon> personen = new List<Sparta.Model.Persoon>();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();
            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT PersoonId, Naam, Achternaam, Categorie, GeboorteDatum FROM Persoon;");
            String sql = sbquery.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sparta.Model.Persoon persoon = new Sparta.Model.Persoon();

                persoon.Persoonid = (int)reader["PersoonId"];
                persoon.Naam = (string)reader["Naam"];
                persoon.Achternaam = (string)reader["Achternaam"];
                persoon.Categorie = (Model.DeelnemerCategorie)reader["Catergorie"];
                persoon.Geboortedatum = (DateTime)reader["GeboorteDatum"];

                personen.Add(persoon);
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);

            return personen;
        }      
               
    }

}

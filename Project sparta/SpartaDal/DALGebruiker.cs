using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALGebruiker
    {
        //AANMELDEN
        public static Model.Persoon checkCredentials(Model.Login user)
        {
            int persoonId = GetLogin(user);

            Model.Persoon p = new Model.Persoon();
            p = GetPersoon(persoonId);
            return p;
        }

        public static int GetLogin(Model.Login user)
        {
            SqlConnection connection = DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT PersoonId FROM Login WHERE AanmeldNaam = '@id' AND PwdHash = '@ww';");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            //aanmeldnaam
            SqlParameter IdParam = new SqlParameter("@id", System.Data.SqlDbType.NVarChar, -1);
            IdParam.Value = user.Naam;
            command.Parameters.Add(IdParam);
            command.Prepare();

            //pwshash
            SqlParameter wwParam = new SqlParameter("@ww", System.Data.SqlDbType.NChar, -1);
            wwParam.Value = user.Pwdhash;
            command.Parameters.Add(wwParam);
            command.Prepare();

            SqlDataReader reader = command.ExecuteReader();

            int persoonid = 0;

            while (reader.Read())
            {
                persoonid = (int)reader["PersoonId"];
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return persoonid;
        }

        public static Model.Persoon GetPersoon(int PersoonId)
        {
            Model.Persoon p = new Model.Persoon();

            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT * FROM Persoon WHERE PersoonId = "+ PersoonId +";");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                p.Persoonid = (int)reader["PersoonId"];
                p.Naam = (string)reader["Naam"];
                p.Achternaam = (string)reader["Achternaam"];
                p.Categorie = (Model.DeelnemerCategorie)reader["Catergorie"];
                p.Geboortedatum = (DateTime)reader["GeboorteDatum"];
            }
            reader.Close();
            DALConnection.sluitConnectieDB(connection);
            return p;
        }
        
        public static void RegistreerPersoon(Model.DeelnemerCategorie categorie, string naam, string achternaam, DateTime gbdatum, Model.Login aanmeld)
        {
            int id = nieuwPersoon(categorie, naam, achternaam, gbdatum);
            NieuweLogin(aanmeld, id);
        }

        public static int nieuwPersoon(Model.DeelnemerCategorie categorie, string naam, string achternaam, DateTime gbdatum)
        {
            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("INSERT INTO Persoon (Naam,Achternaam,Categorie,GeboorteDatum) OUTPUT INSERTED.PersoonId Values('@naam', '@achternaam',@categorie, '@gbdatum'); ");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            //naam 
            SqlParameter naamParam = new SqlParameter("@naam", System.Data.SqlDbType.NVarChar, -1);
            command.Parameters.Add(naamParam);
            naamParam.Value = naam;
            command.Prepare();

            //achternaam
            SqlParameter achtParam = new SqlParameter("@achternaam", System.Data.SqlDbType.NVarChar, -1);
            command.Parameters.Add(achtParam);
            naamParam.Value = achternaam;
            command.Prepare();

            //categorie
            SqlParameter catParam = new SqlParameter("@categorie", System.Data.SqlDbType.Int, -1);
            command.Parameters.Add(catParam);
            naamParam.Value = categorie;
            command.Prepare();

            //datum
            SqlParameter gbdatumParam = new SqlParameter("@gbdatum", System.Data.SqlDbType.Date, -1);
            command.Parameters.Add(gbdatumParam);
            naamParam.Value = gbdatum;
            command.Prepare();

            int PersoonId = 0;
            var id = command.ExecuteScalar();
            PersoonId = int.Parse(id.ToString());
            
            DALConnection.sluitConnectieDB(connection);
            return PersoonId;
        }

        public static void NieuweLogin(Model.Login aanmeld, int id)
        {
            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("INSERT INTO Login (AanmeldNaam,PwdHash, PersoonId) Values('@aanmeldnaam','@pwdhash',"+id+"); ");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            //aanmeldnaam 
            SqlParameter aanmeldnaamParam = new SqlParameter("@aanmeldnaam", System.Data.SqlDbType.NVarChar, -1);
            command.Parameters.Add(aanmeldnaamParam);
            aanmeldnaamParam.Value = aanmeld.Naam;
            command.Prepare();

            //wwhash
            SqlParameter pwdhashParam = new SqlParameter("@pwdhash", System.Data.SqlDbType.NChar, -1);
            command.Parameters.Add(pwdhashParam);
            pwdhashParam.Value = aanmeld.Pwdhash;
            command.Prepare();

            command.ExecuteNonQuery();
                        
            DALConnection.sluitConnectieDB(connection);            
        }


        //WIJZIG WACHTWOORD
        public static void UpdatePwd(int loginid, string pwdhash)
        {
            SqlConnection connection = DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("INSERT INTO Login (AanmeldNaam,PwdHash, PersoonId) Values('@aanmeldnaam','@pwdhash', '@id');");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            ////aanmeldnaam 
            //SqlParameter aanmeldnaamParam = new SqlParameter("@aanmeldnaam", System.Data.SqlDbType.NVarChar);
            //command.Parameters.Add(aanmeldnaamParam);
            //aanmeldnaamParam.Value = aanmeld.Naam;
            //command.Prepare();

            ////wwhash
            //SqlParameter pwdhashParam = new SqlParameter("@pwdhash", System.Data.SqlDbType.NChar);
            //command.Parameters.Add(pwdhashParam);
            //pwdhashParam.Value = aanmeld.Pwdhash;
            //command.Prepare();

            command.ExecuteNonQuery();

            DALConnection.sluitConnectieDB(connection);
        }

        public static int GetLoginId(int persoonid, string pwdhash)
        {
            SqlConnection connection = DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT LoginId FROM Login WHERE AanmeldNaam = '" + persoonid+ "' AND PwdHash = '" + pwdhash + "';");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            int id = (int)reader["LoginId"];

            DALConnection.sluitConnectieDB(connection);

            return id;
        }


    }
}

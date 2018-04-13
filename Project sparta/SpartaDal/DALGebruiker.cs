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
        public static Model.Persoon checkCredentials(Model.Login user)
        {
            Model.Persoon p = new Model.Persoon();
            int Persoonid = GetLogin(user);
            GetPersoon(Persoonid, p);
            return p;
        }

        public static int GetLogin(Model.Login user)
        {
            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();

            //StringBuilder sbquery = new StringBuilder();
            //sbquery.Append("SELECT PersoonId FROM Login WHERE AanmeldNaam = '@id' AND PwdHash = '@ww';");
            //String sql = sbquery.ToString();
            //SqlCommand command = new SqlCommand(sql, connection);

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT PersoonId FROM Login WHERE AanmeldNaam = '@id';");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);

            //StringBuilder sbquery = new StringBuilder();
            //sbquery.Append("SELECT PersoonId FROM Login WHERE PwdHash = '@ww';");
            //String sql = sbquery.ToString();
            //SqlCommand command = new SqlCommand(sql, connection);

            //aanmeldnaam
            SqlParameter IdParam = new SqlParameter("@id", System.Data.SqlDbType.NVarChar, 50, "AanmeldNaam");
            IdParam.Value = user.Naam;
            command.Parameters.Add(IdParam);
            command.Prepare();

            //pwshash
            SqlParameter wwParam = new SqlParameter("@ww", System.Data.SqlDbType.NChar, 32, "PwdHash");
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

        public static Model.Persoon GetPersoon(int PersoonId, Model.Persoon p)
        {
            SqlConnection connection = DALConnection.openConnectieDB();
            DALConnection.openConnectieDB();

            StringBuilder sbquery = new StringBuilder();
            sbquery.Append("SELECT * FROM Persoon WHERE PersoonId = "+ PersoonId +"");
            String sql = sbquery.ToString();
            SqlCommand command = new SqlCommand(sql, connection);
                        
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                p.Persoonid = (int)reader["PersoonId"];
                p.Naam = (string)reader["Naam"];
                p.Achternaam = (string)reader["Achternaam"];
                p.Categorie = (Model.DeelnemerCategorie)reader["Categorie"];
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
            SqlParameter naamParam = new SqlParameter("@naam", System.Data.SqlDbType.NVarChar, 50, "Naam");
            command.Parameters.Add(naamParam);
            naamParam.Value = naam;
            command.Prepare();

            //achternaam
            SqlParameter achtParam = new SqlParameter("@achternaam", System.Data.SqlDbType.NVarChar, 50, "Achternaam");
            command.Parameters.Add(achtParam);
            naamParam.Value = achternaam;
            command.Prepare();

            //categorie
            SqlParameter catParam = new SqlParameter("@categorie", System.Data.SqlDbType.Int, 4, "Categorie");
            command.Parameters.Add(catParam);
            naamParam.Value = categorie;
            command.Prepare();

            //datum
            SqlParameter gbdatumParam = new SqlParameter("@gbdatum", System.Data.SqlDbType.Date,3 , "GeboorteDatum");
            command.Parameters.Add(gbdatumParam);
            naamParam.Value = gbdatum;
            command.Prepare();

            //SqlDataReader reader = command.ExecuteScalar();

            int PersoonId = Convert.ToInt32(command.ExecuteScalar());            

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
            SqlParameter aanmeldnaamParam = new SqlParameter("@aanmeldnaam", System.Data.SqlDbType.NVarChar, 50, "AanmeldNaam");
            command.Parameters.Add(aanmeldnaamParam);
            aanmeldnaamParam.Value = aanmeld.Naam;
            command.Prepare();

            //wwhash
            SqlParameter pwdhashParam = new SqlParameter("@pwdhash", System.Data.SqlDbType.NChar, 32, "PwdHash");
            command.Parameters.Add(pwdhashParam);
            pwdhashParam.Value = aanmeld.Pwdhash;
            command.Prepare();

            command.ExecuteNonQuery();
                        
            DALConnection.sluitConnectieDB(connection);            
        }

        //public static void UpdatePwd(int loginid, string pwdhash)
        //{
        //    SqlConnection connection = DALConnection.openConnectieDB();
        //    DALConnection.openConnectieDB();

        //    StringBuilder sbquery = new StringBuilder();
        //    sbquery.Append("INSERT INTO Login (AanmeldNaam,PwdHash, PersoonId) Values('@aanmeldnaam','@pwdhash'," + id + "); ");
        //    String sql = sbquery.ToString();
        //    SqlCommand command = new SqlCommand(sql, connection);

        //    //aanmeldnaam 
        //    SqlParameter aanmeldnaamParam = new SqlParameter("@aanmeldnaam", System.Data.SqlDbType.NVarChar);
        //    command.Parameters.Add(aanmeldnaamParam);
        //    aanmeldnaamParam.Value = aanmeld.Naam;
        //    command.Prepare();

        //    //wwhash
        //    SqlParameter pwdhashParam = new SqlParameter("@pwdhash", System.Data.SqlDbType.NChar);
        //    command.Parameters.Add(pwdhashParam);
        //    pwdhashParam.Value = aanmeld.Pwdhash;
        //    command.Prepare();

        //    command.ExecuteNonQuery();

        //    DALConnection.sluitConnectieDB(connection);
        //}
    }
}

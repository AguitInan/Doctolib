using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DoctolibMVVM.Tools;

namespace DoctolibMVVM.Classes
{
    class Medecin : AbstractModelWithNotification
    {
        private int id;
        private string codeMedecin;
        private string nomMedecin;
        private string telMedecin;
        private DateTime dateEmbauche;
        private string specialiteMedecin;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string CodeMedecin { get => codeMedecin; set { codeMedecin = value; RaisePropertyChange("CodeMedecin"); } }
        public string NomMedecin { get => nomMedecin; set { nomMedecin = value; RaisePropertyChange("NomMedecin"); } }
        public string TelMedecin { get => telMedecin; set { telMedecin = value; RaisePropertyChange("TelMedecin"); } }



        public DateTime DateEmbauche { get => dateEmbauche; set { dateEmbauche = value; RaisePropertyChange("DateEmbauche"); } }
        public string SpecialiteMedecin { get => specialiteMedecin; set { specialiteMedecin = value; RaisePropertyChange("SpecialiteMedecin"); } }

        public Medecin()
        {

        }


        public bool Save()
        {
            string request = "INSERT INTO medecin (codeMedecin, nomMedecin, telMedecin, dateEmbauche, specialiteMedecin) OUTPUT INSERTED.ID values (@codeMedecin, @nomMedecin,@telMedecin, @dateEmbauche, @specialiteMedecin)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@nomMedecin", NomMedecin));
            command.Parameters.Add(new SqlParameter("@telMedecin", TelMedecin));
            command.Parameters.Add(new SqlParameter("@dateEmbauche", DateEmbauche));
            command.Parameters.Add(new SqlParameter("@specialiteMedecin", SpecialiteMedecin));
            //command.Parameters.Add(new SqlParameter("@specialiteMedecin", 1));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Id > 0;
        }

        public bool Delete()
        {
            //Instruction de suppression dans la base de données
            string request = "DELETE FROM medecin where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public bool Update()
        {
            //Instruction Mise à jour dans la base de données après modification
            string request = "update medecin set codeMedecin = @codeMedecin, nomMedecin=@nomMedecin, telMedecin=@telMedecin, dateEmbauche=@dateEmbauche, specialiteMedecin=@specialiteMedecin  where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@nomMedecin", NomMedecin));
            command.Parameters.Add(new SqlParameter("@telMedecin", TelMedecin));
            command.Parameters.Add(new SqlParameter("@dateEmbauche", DateEmbauche));
            command.Parameters.Add(new SqlParameter("@specialiteMedecin", SpecialiteMedecin));
            //command.Parameters.Add(new SqlParameter("@specialiteMedecin", 1));
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }


        public static List<Medecin> GetMedecins()
        {
            List<Medecin> medecins = new List<Medecin>();
            string request = "SELECT " +
                "m.id, m.codeMedecin, m.nomMedecin, m.telMedecin, m.dateEmbauche, m.specialiteMedecin" +
                " from medecin m";


            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            Medecin medecin = null;
            while (reader.Read())
            {
                if (medecin == null || medecin.Id != reader.GetInt32(0))
                {
                    medecin = new Medecin
                    {
                        Id = reader.GetInt32(0),
                        CodeMedecin = reader.GetString(1),
                        NomMedecin = reader.GetString(2),
                        TelMedecin = reader.GetString(3),
                        DateEmbauche = reader.GetDateTime(4),
                        SpecialiteMedecin = reader.GetString(5),
                    };
                    medecins.Add(medecin);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return medecins;
        }

        public static Medecin GetMedecinById(string codeMedecin)
        {
            Medecin medecin = null;
            //Une méthode pour récupérer un médecin avec son id
            string request = "SELECT " +
                "m.id, m.codeMedecin, m.nomMedecin, m.telMedecin, m.dateEmbauche, m.specialiteMedecin" +
                " from medecin m" +
                " where m.codeMedecin = @codeMedecin";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codeMedecin", codeMedecin));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                medecin = new Medecin
                {
                    Id = reader.GetInt32(0),
                    CodeMedecin = reader.GetString(1),
                    NomMedecin = reader.GetString(2),
                    TelMedecin = reader.GetString(3),
                    DateEmbauche = reader.GetDateTime(4),
                    SpecialiteMedecin = reader.GetString(5),
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return medecin;
        }

        public static List<string> GetCodeMedecin()
        {
            List<string> codes = new List<string>();
            string request = "SELECT " +
                "m.codeMedecin" +
                " from medecin m";


            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            string code;
            while (reader.Read())
            {


                code = reader.GetString(0);
                  
                    
                    codes.Add(code);
                
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return codes;
        }

        public static List<Medecin> SearchMedecins(string search)
        {

            List<Medecin> medecins = new List<Medecin>();
            string request = "SELECT " +
                "m.id, m.codeMedecin, m.nomMedecin, m.telMedecin, m.dateEmbauche, m.specialiteMedecin" +
                " from medecin m" +
                " where " +
                "m.codeMedecin like @search OR m.nomMedecin like @search OR m.telMedecin like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medecin medecin = new Medecin
                {
                    Id = reader.GetInt32(0),
                    CodeMedecin = reader.GetString(1),
                    NomMedecin = reader.GetString(2),
                    TelMedecin = reader.GetString(3),
                    DateEmbauche = reader.GetDateTime(4),
                    SpecialiteMedecin = reader.GetString(5),
                };
                medecins.Add(medecin);
            }
            reader.Close();
            command.Dispose();

            //Requete 2
            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);
            //executer la commande


            DataBase.Connection.Close();
            return medecins;
        }
    }
}

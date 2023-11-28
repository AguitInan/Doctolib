using DoctolibMVVM.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DoctolibMVVM.Classes
{
    class RDV : AbstractModelWithNotification
    {
        private int id;
        private int numeroRDV;
        private DateTime dateRDV;
        private string heureRDV;
        private string codeMedecin;
        private string codePatient;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public int NumeroRDV { get => numeroRDV; set { numeroRDV = value; RaisePropertyChange("NumeroRDV"); } }
        public DateTime DateRDV { get => dateRDV; set { dateRDV = value; RaisePropertyChange("DateRDV"); } }
        public string HeureRDV { get => heureRDV; set { heureRDV = value; RaisePropertyChange("HeureRDV"); } }
        public string CodeMedecin { get => codeMedecin; set { codeMedecin = value; RaisePropertyChange("CodeMedecin"); } }
        public string CodePatient { get => codePatient; set { codePatient = value; RaisePropertyChange("CodePatient"); } }

       

        public RDV()
        {

        }

        public bool Save()
        {
            string request = "INSERT INTO rdv (dateRDV, heureRDV, codeMedecin, codePatient) OUTPUT INSERTED.ID values (@dateRDV,@heureRDV, @codeMedecin, @codePatient)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@dateRDV", DateRDV));
            command.Parameters.Add(new SqlParameter("@heureRDV", HeureRDV));
            command.Parameters.Add(new SqlParameter("@codeMedecin", CodeMedecin));
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
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
            string request = "DELETE FROM rdv where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<RDV> GetRdvs()
        {
            List<RDV> rdvs = new List<RDV>();
            string request = "SELECT " +
                "r.id, r.dateRDV, r.heureRDV, r.codeMedecin, r.codePatient" +
                " from rdv r";


            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            RDV rdv = null;
            while (reader.Read())
            {
                if (rdv == null || rdv.Id != reader.GetInt32(0))
                {
                    rdv = new RDV
                    {
                        Id = reader.GetInt32(0),
                        DateRDV = reader.GetDateTime(1),
                        HeureRDV = reader.GetString(2),
                        CodeMedecin = reader.GetString(3),
                        CodePatient = reader.GetString(4),
                    };
                    rdvs.Add(rdv);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return rdvs;
        }

        //public static List<RDV> GetRdvs()
        //{
        //    List<RDV> rdvs = new List<RDV>();
        //    string request = "SELECT " +
        //        " r.id, r.dateRDV, r.heureRDV, r.codeMedecin, r.codePatient, m.nomMedecin, m.specialiteMedecin, p.nomPatient, p.dateNaissance, p.sexePatient" +
        //        " from rdv r inner join medecin m on r.codeMedecin=m.codeMedecin  inner join patient p on r.codePatient=p.codePatient";


        //    command = new SqlCommand(request, DataBase.Connection);
        //    DataBase.Connection.Open();
        //    reader = command.ExecuteReader();
        //    RDV rdv = null;
        //    while (reader.Read())
        //    {
        //        if (rdv == null || rdv.Id != reader.GetInt32(0))
        //        {
        //            rdv = new RDV
        //            {
        //                Id = reader.GetInt32(0),
        //                DateRDV = reader.GetDateTime(1),
        //                HeureRDV = reader.GetString(2),
        //                CodeMedecin = reader.GetString(3),
        //                CodePatient = reader.GetString(4),
        //            };
        //            rdvs.Add(rdv);
        //        }
        //    }
        //    reader.Close();
        //    command.Dispose();
        //    DataBase.Connection.Close();
        //    return rdvs;
        //}

        public static List<RDV> SearchRdvsByDate(string search)
        {

            List<RDV> rdvs = new List<RDV>();
            string request = "SELECT " +
                "r.id, r.dateRDV, r.heureRDV, r.codeMedecin, r.codePatient" +
                " from rdv r" +
                " where " +
                "CONVERT(VARCHAR(25), r.dateRDV, 126) like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                RDV rdv = new RDV
                {
                    Id = reader.GetInt32(0),
                    DateRDV = reader.GetDateTime(1),
                    HeureRDV = reader.GetString(2),
                    CodeMedecin = reader.GetString(3),
                    CodePatient = reader.GetString(4),
                };
                rdvs.Add(rdv);
            }
            reader.Close();
            command.Dispose();

            //Requete 2
            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);
            //executer la commande


            DataBase.Connection.Close();
            return rdvs;
        }


        public static List<RDV> SearchRdvsByPatient(string search)
        {

            List<RDV> rdvs = new List<RDV>();
            string request = "SELECT " +
                "r.id, r.dateRDV, r.heureRDV, r.codeMedecin, r.codePatient" +
                " from rdv r" +
                " where " +
                "r.codePatient like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                RDV rdv = new RDV
                {
                    Id = reader.GetInt32(0),
                    DateRDV = reader.GetDateTime(1),
                    HeureRDV = reader.GetString(2),
                    CodeMedecin = reader.GetString(3),
                    CodePatient = reader.GetString(4),
                };
                rdvs.Add(rdv);
            }
            reader.Close();
            command.Dispose();

            //Requete 2
            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);
            //executer la commande


            DataBase.Connection.Close();
            return rdvs;
        }


    }
}

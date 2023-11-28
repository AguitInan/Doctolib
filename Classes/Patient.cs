using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DoctolibMVVM.Tools;

namespace DoctolibMVVM.Classes
{
    class Patient : AbstractModelWithNotification
    {
        private int id;
        private string codePatient;
        private string nomPatient;
        private string adressePatient;
        private DateTime dateNaissance;
        private string sexePatient;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string CodePatient { get => codePatient; set { codePatient = value; RaisePropertyChange("CodePatient"); } }
        public string NomPatient { get => nomPatient; set { nomPatient = value; RaisePropertyChange("NomPatient"); } }
        public string AdressePatient { get => adressePatient; set { adressePatient = value; RaisePropertyChange("AdressePatient"); } }
        public DateTime DateNaissance { get => dateNaissance; set { dateNaissance = value; RaisePropertyChange("DateNaissance"); } }
        public string SexePatient { get => sexePatient; set { sexePatient = value; RaisePropertyChange("SexePatient"); } }



        public Patient()
        {

        }

        public bool Save()
        {
            string request = "INSERT INTO patient (codePatient, nomPatient, adressePatient, dateNaissance, sexePatient) OUTPUT INSERTED.ID values (@codePatient, @nomPatient,@adressePatient, @dateNaissance, @sexePatient)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
            command.Parameters.Add(new SqlParameter("@nomPatient", NomPatient));
            command.Parameters.Add(new SqlParameter("@adressePatient", AdressePatient));
            command.Parameters.Add(new SqlParameter("@dateNaissance", DateNaissance));
            command.Parameters.Add(new SqlParameter("@sexePatient", SexePatient));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Id > 0;
        }

        public bool Delete()
        {
            //Instruction de suppression dans la base de données
            string request = "DELETE FROM patient where id=@id";
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
            string request = "update patient set codePatient = @codePatient, nomPatient=@nomPatient, adressePatient=@adressePatient, dateNaissance=@dateNaissance, sexePatient=@sexePatient  where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", CodePatient));
            command.Parameters.Add(new SqlParameter("@nomPatient", NomPatient));
            command.Parameters.Add(new SqlParameter("@adressePatient", AdressePatient));
            command.Parameters.Add(new SqlParameter("@dateNaissance", DateNaissance));
            command.Parameters.Add(new SqlParameter("@sexePatient", SexePatient));
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nbRow == 1;
        }

        public static List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            string request = "SELECT id, codePatient, nomPatient, adressePatient, dateNaissance, sexePatient from patient ";


            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            Patient patient = null;
            while (reader.Read())
            {
                if (patient == null || patient.Id != reader.GetInt32(0))
                {
                    patient = new Patient
                    {
                        Id = reader.GetInt32(0),
                        CodePatient = reader.GetString(1),
                        NomPatient = reader.GetString(2),
                        AdressePatient = reader.GetString(3),
                        DateNaissance = reader.GetDateTime(4),
                        SexePatient = reader.GetString(5),
                    };
                    patients.Add(patient);
                }
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patients;
        }

        public static Patient GetPatientById(string codePatient)
        {
            Patient patient = null;
            //Une méthode pour récupérer un médecin avec son id
            string request = "SELECT id, codePatient, nomPatient, adressePatient, dateNaissance, sexePatient from patient " +
                " where codePatient = @codePatient";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@codePatient", codePatient));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                patient = new Patient
                {
                    Id = reader.GetInt32(0),
                    CodePatient = reader.GetString(1),
                    NomPatient = reader.GetString(2),
                    AdressePatient = reader.GetString(3),
                    DateNaissance = reader.GetDateTime(4),
                    SexePatient = reader.GetString(5),
                };
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return patient;
        }

        public static List<string> GetCodePatient()
        {
            List<string> codes = new List<string>();
            string request = "SELECT " +
                "p.codePatient" +
                " from patient p";


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

        public static List<Patient> SearchPatients(string search)
        {
            List<Patient> patients = new List<Patient>();
            string request = "SELECT id, codePatient, nomPatient, adressePatient, dateNaissance, sexePatient from patient where " +
                "codePatient like @search OR nomPatient like @search";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@search", $"{search}%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Patient patient = new Patient
                {
                    Id = reader.GetInt32(0),
                    CodePatient = reader.GetString(1),
                    NomPatient = reader.GetString(2),
                    AdressePatient = reader.GetString(3),
                    DateNaissance = reader.GetDateTime(4),
                    SexePatient = reader.GetString(5),
                };
                patients.Add(patient);
            }
            reader.Close();
            command.Dispose();

            //Requete 2
            request = "deuxième requete";
            command = new SqlCommand(request, DataBase.Connection);
            //executer la commande


            DataBase.Connection.Close();
            return patients;
        }
    }
}

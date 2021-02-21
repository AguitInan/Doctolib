using System;
using System.Collections.Generic;
using System.Text;

namespace Doctolib.Classes
{
    class Patient
    {
        private string codePatient;
        private string nomPatient;
        private string adressePatient;
        private DateTime dateNaissance;
        private string sexePatient;

        public string CodePatient { get => codePatient; set => codePatient = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string AdressePatient { get => adressePatient; set => adressePatient = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string SexePatient { get => sexePatient; set => sexePatient = value; }
    }
}

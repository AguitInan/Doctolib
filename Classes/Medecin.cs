using System;
using System.Collections.Generic;
using System.Text;

namespace Doctolib.Classes
{
    class Medecin
    {
        private string codeMedecin;
        private string nomMedecin;
        private string telMedecin;
        private DateTime dateEmbauche;
        private string specialiteMedecin;

        public string CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public string NomMedecin { get => nomMedecin; set => nomMedecin = value; }
        public string TelMedecin { get => telMedecin; set => telMedecin = value; }
        public DateTime DateEmbauche { get => dateEmbauche; set => dateEmbauche = value; }
        public string SpecialiteMedecin { get => specialiteMedecin; set => specialiteMedecin = value; }
    }
}

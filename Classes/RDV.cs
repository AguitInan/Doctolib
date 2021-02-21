using System;
using System.Collections.Generic;
using System.Text;

namespace Doctolib.Classes
{
    class RDV
    {
        private int numeroRDV;
        private DateTime dateRDV;
        private string heureRDV;
        private string codeMedecin;
        private string codePatient;

        public int NumeroRDV { get => numeroRDV; set => numeroRDV = value; }
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string HeureRDV { get => heureRDV; set => heureRDV = value; }
        public string CodeMedecin { get => codeMedecin; set => codeMedecin = value; }
        public string CodePatient { get => codePatient; set => codePatient = value; }
    }
}

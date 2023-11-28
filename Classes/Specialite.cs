using System;
using System.Collections.Generic;
using System.Text;

namespace DoctolibMVVM.Classes
{
    class Specialite
    {
        private int idSpecialite;
        private string intituleSpecialite;

        public int IdSpecialite { get => idSpecialite; set => idSpecialite = value; }
        public string IntituleSpecialite { get => intituleSpecialite; set => intituleSpecialite = value; }
    }
}

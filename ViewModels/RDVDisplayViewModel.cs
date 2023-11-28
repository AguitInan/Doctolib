using DoctolibMVVM.Classes;
using DoctolibMVVM.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DoctolibMVVM.ViewModels
{
    class RDVDisplayViewModel : ViewModelBase
    {
        private RDV rdv;
        private Medecin medecin;
        private Patient patient;
        private RDVDisplayControl _mainWindow;

        public RDV Rdv { get => rdv; set { rdv = value; if (value != null) RaiseAllChanged(); } }
        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChanged(); } }
        public Patient Patient { get => patient; set { patient = value; if (value != null) RaiseAllChanged(); } }




        public int NumeroRDV { get => Rdv.NumeroRDV; set { Rdv.NumeroRDV = value; RaisePropertyChanged("NumeroRDV"); } }
        public DateTime DateRDV { get => Rdv.DateRDV; set { Rdv.DateRDV = value; RaisePropertyChanged("DateRDV"); } }
        public string HeureRDV { get => Rdv.HeureRDV; set { Rdv.HeureRDV = value; RaisePropertyChanged("HeureRDV"); } }



        public string CodeMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).NomMedecin : null; set { Rdv.CodeMedecin = value; RaisePropertyChanged("CodeMedecin"); } }
        public string CodePatient { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).CodePatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("CodePatient"); } }
        public string NomPatient { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).NomPatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("NomPatient"); } }
        public string SexePatient { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).SexePatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("NomPatient"); } }
        public DateTime DateNaissance { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).DateNaissance : DateTime.Now; set { Patient.GetPatientById(Rdv.CodePatient).DateNaissance = value; RaisePropertyChanged("NomPatient"); } }
        public string NomMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).NomMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string SpecialiteMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).SpecialiteMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string TelMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).TelMedecin : null; set { Medecin.TelMedecin = value; RaisePropertyChanged("TelMedecin"); } }


        public string Search { get; set; }
        public ICommand SearchCommand { get; set; }
        public ObservableCollection<Medecin> Medecins { get; set; }

        public ObservableCollection<Patient> Patients { get; set; }

        public ObservableCollection<RDV> Rdvs { get; set; }

        public RDVDisplayViewModel(RDVDisplayControl mainWindow)
        {
            Rdv = new RDV();
            Medecin = new Medecin();
            Patient = new Patient();


            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());


            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            Rdvs = new ObservableCollection<RDV>(RDV.GetRdvs());

            SearchCommand = new RelayCommand(ActionSearchCommand);

            DateRDV = DateTime.Now;
            _mainWindow = mainWindow;
        }

        private void ActionSearchCommand()
        {
            Rdvs = new ObservableCollection<RDV>(RDV.SearchRdvsByDate(Search));
            RaisePropertyChanged("Rdvs");
        }

        private void RaiseAllChanged()
        {
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("SexePatient");
            RaisePropertyChanged("DateNaissance");


            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("TelMedecin");
            RaisePropertyChanged("DateEmbauche");
            RaisePropertyChanged("SpecialiteMedecin");




            RaisePropertyChanged("Rdv");
            RaisePropertyChanged("Medecin");
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("NumeroRDV");
            RaisePropertyChanged("DateRDV");
            RaisePropertyChanged("HeureRDV");
            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("SpecialiteMedecin");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("SexePatient");
        }
    }
}

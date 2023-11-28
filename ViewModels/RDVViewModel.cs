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
    class RDVViewModel : ViewModelBase
    {
        private RDV rdv;
        private Medecin medecin;
        private Patient patient;
        private RDVControl _mainWindow;
        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChanged(); } }
        public Patient Patient { get => patient; set { patient = value; if (value != null) RaiseAllChanged(); } }

        public RDV Rdv { get => rdv; set { rdv = value; if (value != null) RaiseAllChanged(); } }


        public int NumeroRDV { get => Rdv.NumeroRDV; set { Rdv.NumeroRDV = value; RaisePropertyChanged("NumeroRDV"); } }
        public DateTime DateRDV { get => Rdv.DateRDV; set { Rdv.DateRDV = value; RaisePropertyChanged("DateRDV"); } }
        public string HeureRDV { get => Rdv.HeureRDV; set { Rdv.HeureRDV = value; RaisePropertyChanged("HeureRDV"); } }
        public string CodeMedecin { get => (Medecin != null) ? Medecin.CodeMedecin : null; set { Medecin.CodeMedecin = value; RaisePropertyChanged("CodeMedecin"); } }
        public string CodePatient { get => (Patient != null) ? Patient.CodePatient : null; set { Patient.CodePatient = value; RaisePropertyChanged("CodePatient"); } }


        public string NomMedecin { get => (Medecin != null) ? Medecin.NomMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string SpecialiteMedecin { get => (Medecin != null) ? Medecin.SpecialiteMedecin : null; set { Medecin.SpecialiteMedecin = value; RaisePropertyChanged("SpecialiteMedecin"); } }

        public string NomPatient { get => (Patient != null) ? Patient.NomPatient : null; set { Patient.NomPatient = value; RaisePropertyChanged("NomPatient"); } }
        public string SexePatient { get => (Patient != null) ? Patient.SexePatient : null; set { Patient.SexePatient = value; RaisePropertyChanged("SexePatient"); } }


        // public string NomMedecin { get => Medecin.NomMedecin; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }




        public ICommand AddCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        public ObservableCollection<Medecin> Medecins { get; set; }

        public ObservableCollection<Patient> Patients { get; set; }

        public ObservableCollection<RDV> Rdvs { get; set; }
        public ObservableCollection<string> CodesMedecin { get; set; }
        public ObservableCollection<string> CodesPatient { get; set; }
        

        public RDVViewModel(RDVControl mainWindow)
        {
            Rdv = new RDV();
            Medecin = new Medecin();
            Patient = new Patient();
         

            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());
            //CodesMedecin = new ObservableCollection<string>(Medecin.GetCodeMedecin());
           // CodesPatient = new ObservableCollection<string>(Patient.GetCodePatient());

            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            Rdvs = new ObservableCollection<RDV>();
            DateRDV = DateTime.Now;

            AddCommand = new RelayCommand(ActionAddCommand);
            NewCommand = new RelayCommand(ActionNewCommand);
            ExitCommand = new RelayCommand(ActionExitCommand);
            _mainWindow = mainWindow;
        }

        public void ActionAddCommand()
        {
            Rdv.CodeMedecin = CodeMedecin;
            Rdv.CodePatient = CodePatient;
            
            if (Rdv.Id == 0 && Rdv.Save())
            {
                Rdvs.Add(Rdv);

                MessageBox.Show("RDV ajouté");
                Rdv = new RDV();

                RaiseAllChanged();
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        public void ActionNewCommand()
        {
            Rdv = new RDV();
            DateRDV = DateTime.Now;
            Medecin = null;
            Patient = null;
            HeureRDV = "";
            RaiseAllChanged();
        }

        public void ActionExitCommand()
        {
            Application.Current.MainWindow.Close();
        }


        private void RaiseAllChanged()
        {
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

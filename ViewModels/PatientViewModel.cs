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
    class PatientViewModel : ViewModelBase
    {

        private Patient patient;
        private PatientControl _mainWindow;

        public Patient Patient { get => patient; set { patient = value; if (value != null) RaiseAllChanged(); } }
        public string CodePatient { get => Patient.CodePatient; set { Patient.CodePatient = value; RaisePropertyChanged("CodePatient"); } }
        public string NomPatient { get => Patient.NomPatient; set { Patient.NomPatient = value; RaisePropertyChanged("NomPatient"); } }
        public string AdressePatient { get => Patient.AdressePatient; set { Patient.AdressePatient = value; RaisePropertyChanged("AdressePatient"); } }
        public DateTime DateNaissance { get => Patient.DateNaissance; set { Patient.DateNaissance = value; RaisePropertyChanged("DateNaissance"); } }
        public string SexePatient { get => Patient.SexePatient; set { Patient.SexePatient = value; RaisePropertyChanged("SexePatient"); } }
        public bool M { get { return Patient.SexePatient != null ? Patient.SexePatient.Contains('M') : false; } set { Patient.SexePatient = value ? "M" : "F"; } }
        public bool F { get { return Patient.SexePatient != null ? Patient.SexePatient.Contains('F') : false; } set { Patient.SexePatient = value ? "F" : "M"; } }
        public string Search { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<Patient> Patients { get; set; }

        public PatientViewModel(PatientControl mainWindow)
        {
            Patient = new Patient();
            AddCommand = new RelayCommand(ActionAddCommand);
            DeleteCommand = new RelayCommand(ActionDeleteCommand);
            ModifyCommand = new RelayCommand(ActionModifyCommand);
            SearchCommand = new RelayCommand(ActionSearchCommand);
            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            DateNaissance = DateTime.Now;
            _mainWindow = mainWindow;
        }

        public void ActionAddCommand()
        {
            if (Patient.Id == 0 && Patient.Save())
            {
                Patients.Add(Patient);

                MessageBox.Show("Patient ajouté");
                Patient = new Patient();
                DateNaissance = DateTime.Now;
                RaiseAllChanged();
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        public void ActionDeleteCommand()
        {
            if (Patient.Id > 0)
            {
                if (Patient.Delete())
                {
                    Patients.Remove(Patient);
                    MessageBox.Show("Patient supprimé");
                    Patient = new Patient();
                    DateNaissance = DateTime.Now;
                    RaiseAllChanged();
                }
            }
        }

        public void ActionModifyCommand()
        {
            if (Patient.Id == 0 && Patient.Save())
            {
                Patients.Add(Patient);

                MessageBox.Show("Patient ajouté");
                Patient = new Patient();
                DateNaissance = DateTime.Now;
                RaiseAllChanged();
                
            }
            else if (Patient.Id > 0 && Patient.Update())
            {
                MessageBox.Show("Mise à jour du patient effectuée");
                Patient = new Patient();
                DateNaissance = DateTime.Now;
                RaiseAllChanged();
               
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void ActionSearchCommand()
        {
            Patients = new ObservableCollection<Patient>(Patient.SearchPatients(Search));
            RaisePropertyChanged("Patients");
        }




        private void RaiseAllChanged()
        {
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("AdressePatient");
            RaisePropertyChanged("DateNaissance");
            RaisePropertyChanged("SexePatient");
            RaisePropertyChanged("F");
            RaisePropertyChanged("M");
        }
    }
}

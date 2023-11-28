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
    class RDVPatientViewModel : ViewModelBase
    {
        private Medecin medecin;
        private RDV rdv;
        private RDVPatientControl _mainWindow;

        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChanged(); } }
        public RDV Rdv { get => rdv; set { rdv = value; if (value != null) RaiseAllChanged(); } }
        public string CodeMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).NomMedecin : null; set { Rdv.CodeMedecin = value; RaisePropertyChanged("CodeMedecin"); } }
        public string CodePatient{ get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).CodePatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("CodePatient"); } }
        public string NomPatient{ get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).NomPatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("NomPatient"); } }
        public string SexePatient { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).SexePatient : null; set { Rdv.CodePatient = value; RaisePropertyChanged("NomPatient"); } }
        public DateTime DateNaissance { get => (Rdv.CodePatient != null) ? Patient.GetPatientById(Rdv.CodePatient).DateNaissance : DateTime.Now; set { Patient.GetPatientById(Rdv.CodePatient).DateNaissance = value; RaisePropertyChanged("NomPatient"); } }
        public string NomMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).NomMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string SpecialiteMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).SpecialiteMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string TelMedecin { get => (Rdv.CodeMedecin != null) ? Medecin.GetMedecinById(Rdv.CodeMedecin).TelMedecin : null; set { Medecin.TelMedecin = value; RaisePropertyChanged("TelMedecin"); } }
        public DateTime DateEmbauche { get => Medecin.DateEmbauche; set { Medecin.DateEmbauche = value; RaisePropertyChanged("DateEmbauche"); } }




        public int NumeroRDV { get => Rdv.NumeroRDV; set { Rdv.NumeroRDV = value; RaisePropertyChanged("NumeroRDV"); } }
        public DateTime DateRDV { get => Rdv.DateRDV; set { Rdv.DateRDV = value; RaisePropertyChanged("DateRDV"); } }
        public string HeureRDV { get => Rdv.HeureRDV; set { Rdv.HeureRDV = value; RaisePropertyChanged("HeureRDV"); } }




        public string Search { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<Medecin> Medecins { get; set; }
        public ObservableCollection<RDV> Rdvs { get; set; }
        public ObservableCollection<string> Specialites { get; set; }

        public RDVPatientViewModel(RDVPatientControl mainWindow)
        {
            Medecin = new Medecin();
            Rdv = new RDV();
            AddCommand = new RelayCommand(ActionAddCommand);
            DeleteCommand = new RelayCommand(ActionDeleteCommand);
            ModifyCommand = new RelayCommand(ActionModifyCommand);
            SearchCommand = new RelayCommand(ActionSearchCommand);
            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());
            Rdvs = new ObservableCollection<RDV>(RDV.GetRdvs());
            Specialites = new ObservableCollection<string> { "Allergologie", "Cardiologie", "Chirurgie", "Dermatologie", "Gériatrie", "Oncologie", "Pédiatrie", "Psychiatrie" };
            DateEmbauche = DateTime.Now;
            _mainWindow = mainWindow;
        }

        public void ActionAddCommand()
        {
            if (Medecin.Id == 0 && Medecin.Save())
            {
                Medecins.Add(Medecin);

                MessageBox.Show("Medecin ajouté");
                Medecin = new Medecin();
                DateEmbauche = DateTime.Now;
                RaiseAllChanged();
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        public void ActionDeleteCommand()
        {
            if (Rdv.Id > 0)
            {
                if (Rdv.Delete())
                {
                    Rdvs.Remove(Rdv);
                    MessageBox.Show("RDV supprimé");
                    Rdv = new RDV();
                   // DateEmbauche = DateTime.Now;
                    RaiseAllChanged();
                }
            }
        }


        public void ActionModifyCommand()
        {
            if (Medecin.Id == 0 && Medecin.Save())
            {
                Medecins.Add(Medecin);

                MessageBox.Show("Medecin ajouté");
                Medecin = new Medecin();
                DateEmbauche = DateTime.Now;
                RaiseAllChanged();
            }
            else if (medecin.Id > 0 && Medecin.Update())
            {
                MessageBox.Show("Mise à jour du médecin effectuée");
                Medecin = new Medecin();
                DateEmbauche = DateTime.Now;
                RaiseAllChanged();
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void ActionSearchCommand()
        {
            Rdvs = new ObservableCollection<RDV>(RDV.SearchRdvsByPatient(Search));
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
        }
    }
}
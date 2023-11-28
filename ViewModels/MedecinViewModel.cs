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
    class MedecinViewModel : ViewModelBase
    {
        private Medecin medecin;
        private MedecinControl _mainWindow;

        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChanged(); } }
        public string CodeMedecin { get => Medecin.CodeMedecin; set { Medecin.CodeMedecin = value; RaisePropertyChanged("CodeMedecin"); } }
        public string NomMedecin { get => Medecin.NomMedecin; set { Medecin.NomMedecin = value; RaisePropertyChanged("NomMedecin"); } }
        public string TelMedecin { get => Medecin.TelMedecin; set { Medecin.TelMedecin = value; RaisePropertyChanged("TelMedecin"); } }
        public DateTime DateEmbauche { get => Medecin.DateEmbauche; set { Medecin.DateEmbauche = value; RaisePropertyChanged("DateEmbauche"); } }
        public string SpecialiteMedecin { get => Medecin.SpecialiteMedecin; set { Medecin.SpecialiteMedecin = value; RaisePropertyChanged("SpecialiteMedecin"); } }

        public string Search { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<Medecin> Medecins { get; set; }
        public ObservableCollection<string> Specialites { get; set; }

        public MedecinViewModel(MedecinControl mainWindow)
        {
            Medecin = new Medecin();
            AddCommand = new RelayCommand(ActionAddCommand);
            DeleteCommand = new RelayCommand(ActionDeleteCommand);
            ModifyCommand = new RelayCommand(ActionModifyCommand);
            SearchCommand = new RelayCommand(ActionSearchCommand);
            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());
            Specialites = new ObservableCollection<string> {"Allergologie", "Cardiologie", "Chirurgie", "Dermatologie", "Gériatrie", "Oncologie", "Pédiatrie", "Psychiatrie"};
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
            if (Medecin.Id > 0)
            {
                if (Medecin.Delete())
                {
                    Medecins.Remove(Medecin);
                    MessageBox.Show("Medecin supprimé");
                    Medecin = new Medecin();
                    DateEmbauche = DateTime.Now;
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
            Medecins = new ObservableCollection<Medecin>(Medecin.SearchMedecins(Search));
            RaisePropertyChanged("Medecins");
        }


        private void RaiseAllChanged()
        {
            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("TelMedecin");
            RaisePropertyChanged("DateEmbauche");
            RaisePropertyChanged("SpecialiteMedecin");
        }
    }
}

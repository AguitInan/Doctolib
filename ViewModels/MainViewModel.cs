using DoctolibMVVM.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoctolibMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand MedecinCommand { get; set; }
        public ICommand PatientCommand { get; set; }
        public ICommand RDVCommand { get; set; }
        public ICommand RDVDisplayCommand { get; set; }
        public ICommand RDVPatientCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public MainViewModel()
        {
            MedecinCommand = new RelayCommand<StackPanel>((result) => {
                result.Children.Clear();
                result.Children.Add(new MedecinControl());
            });

            PatientCommand = new RelayCommand<StackPanel>((result) =>
            {
                result.Children.Clear();
                result.Children.Add(new PatientControl());
            });
            RDVCommand = new RelayCommand<StackPanel>((result) =>
            {
                result.Children.Clear();
                result.Children.Add(new RDVControl());
            });

            RDVDisplayCommand = new RelayCommand<StackPanel>((result) =>
            {
                result.Children.Clear();
                result.Children.Add(new RDVDisplayControl());
            });

            RDVPatientCommand = new RelayCommand<StackPanel>((result) => {
                result.Children.Clear();
                result.Children.Add(new RDVPatientControl());
            });

            ExitCommand = new RelayCommand(ActionExitCommand);


        }

        public void ActionExitCommand()
        {
            Application.Current.MainWindow.Close();
        }
    }
}

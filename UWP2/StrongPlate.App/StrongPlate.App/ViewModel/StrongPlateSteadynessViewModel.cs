using StrongPlate.App.Services;
using StrongPlate.App.Utility;
using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StrongPlate.App.ViewModel
{
    public class StrongPlateSteadynessViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IStrongPlateService strongPlateService;

        private IFrameNavigationService frameNavigationService;

        private ObservableCollection<Employee> topEmployees;

        public ICommand BackCommand { get; set; }

        public ObservableCollection<Employee> TopEmployees
        {
            get { return topEmployees; }
            set
            {
                topEmployees = value;
                RaisePropertyChanged();
            }
        }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public StrongPlateSteadynessViewModel(IFrameNavigationService frameNavigationService, IStrongPlateService strongPlateService)
        {
            this.strongPlateService = strongPlateService;
            this.frameNavigationService = frameNavigationService;
            LoadData(); // Doet hetzelfde als de Messenger, maar werkt beter met de tests
            LoadCommands();

            Messenger.Default.Register<ObservableCollection<Employee>>(this, OnEmployeesReceived);
        }

        private void OnEmployeesReceived(ObservableCollection<Employee> employees)
        {
            topEmployees = employees;
            selectedEmployee = topEmployees.First();
        }

        private void LoadData()
        {
            topEmployees = new ObservableCollection<Employee>(strongPlateService.GetTopSteadyness());
            selectedEmployee = topEmployees.First();
        }

        private void LoadCommands()
        {
            BackCommand = new CustomCommand(OpenMainView, CanOpenView);
        }

        private bool CanOpenView(object obj)
        {
            return true;
        }

        private void OpenMainView(object view)
        {
            frameNavigationService.NavigateBack();
        }
    }
}

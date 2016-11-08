using StrongPlate.App.Services;
using StrongPlate.App.Utility;
using StrongPlate.App.View;
using StrongPlate.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StrongPlate.App.ViewModel
{
    public class StrongPlateMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IStrongPlateService strongPlateService;
        private IFrameNavigation frameNavigationService;

        private List<Employee> employees;

        public ICommand SpeedCommand { get; set; }
        public ICommand SteadynessCommand { get; set; }

        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
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

        public StrongPlateMainViewModel(IFrameNavigation frameNavigationService, IStrongPlateService strongPlateService)
        {
            this.strongPlateService = strongPlateService;
            this.frameNavigationService = frameNavigationService;
            LoadData();
            LoadCommands();
        }

        private void LoadData()
        {
            employees = new List<Employee>(strongPlateService.GetAllEmployees());
            selectedEmployee = employees.First();
        }

        private void LoadCommands()
        {
            SpeedCommand = new CustomCommand(OpenSpeedView, CanOpenView);
            SteadynessCommand = new CustomCommand(OpenSteadynessView, CanOpenView);
        }

        private bool CanOpenView(object obj)
        {
            return true;
        }

        private void OpenSpeedView(object view)
        {
            Messenger.Default.Send<List<Employee>>(strongPlateService.GetTopSpeed());
            frameNavigationService.NavigateToFrame(typeof(StrongPlateSpeedView));
        }

        private void OpenSteadynessView(object view)
        {
            Messenger.Default.Send<List<Employee>>(strongPlateService.GetTopSteadyness());
            frameNavigationService.NavigateToFrame(typeof(StrongPlateSteadynessView));
        }
    }
}

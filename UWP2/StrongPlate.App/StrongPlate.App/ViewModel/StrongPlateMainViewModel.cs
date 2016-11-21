using StrongPlate.App.Services;
using StrongPlate.App.Utility;
using StrongPlate.App.View;
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
using Windows.UI.Xaml;

namespace StrongPlate.App.ViewModel
{
    public class StrongPlateMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IStrongPlateService strongPlateService;
        private IFrameNavigationService frameNavigationService;

        private ObservableCollection<Employee> employees;

        public ICommand SpeedCommand { get; set; }
        public ICommand SteadynessCommand { get; set; }
        //public ICommand SearchCommand { get; set; }

        public ObservableCollection<Employee> Employees
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

        /*private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged();
            }
        }*/

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public StrongPlateMainViewModel(IFrameNavigationService frameNavigationService, IStrongPlateService strongPlateService)
        {
            this.strongPlateService = strongPlateService;
            this.frameNavigationService = frameNavigationService;
            LoadData();
            LoadCommands();
        }

        private void LoadData()
        {
            employees = new ObservableCollection<Employee>(strongPlateService.GetAllEmployees());
            selectedEmployee = employees.First();
        }

        private void LoadCommands()
        {
            SpeedCommand = new CustomCommand(OpenSpeedView, CanOpenView);
            SteadynessCommand = new CustomCommand(OpenSteadynessView, CanOpenView);
            //SearchCommand = new CustomCommand(SearchEmployee, CanSearch);
        }

        private bool CanOpenView(object obj)
        {
            return true;
        }

        private void OpenSpeedView(object view)
        {
            Messenger.Default.Send<ObservableCollection<Employee>>(strongPlateService.GetTopSpeed());
            frameNavigationService.NavigateToFrame(typeof(StrongPlateSpeedView));
        }

        private void OpenSteadynessView(object view)
        {
            Messenger.Default.Send<ObservableCollection<Employee>>(strongPlateService.GetTopSteadyness());
            frameNavigationService.NavigateToFrame(typeof(StrongPlateSteadynessView));
        }

        /*private bool CanSearch(object obj)
        {
            return true;
        }

        private void SearchEmployee(object obj)
        {
            if (searchText != null)
            {

                ObservableCollection<Employee> searchedEmployees = new ObservableCollection<Employee>();
                foreach (Employee e in employees)
                {
                    if (e.FullName.ToLower().Contains(searchText.ToLower()))
                        searchedEmployees.Add(e);
                }

                employees = searchedEmployees;
                selectedEmployee = employees.First();
            }
            else
            {
                LoadData();
            }

            RaisePropertyChanged("employees");
        }*/
    }
}

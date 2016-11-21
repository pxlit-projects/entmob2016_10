using StrongPlate.App.Services;
using StrongPlate.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.App.ViewModel
{
    public class ViewModelLocator
    {
        private static IStrongPlateService strongPlateService = new SPService(new SPAPIRepository());
        private static IFrameNavigationService frameNavigationService = new FrameNavigationService();

        private static StrongPlateMainViewModel strongPlateMainViewModel = new StrongPlateMainViewModel(frameNavigationService, strongPlateService);

        public static StrongPlateMainViewModel StrongPlateMainViewModel
        {
            get { return strongPlateMainViewModel; }
        }

        private static StrongPlateSpeedViewModel strongPlateSpeedViewModel = new StrongPlateSpeedViewModel(frameNavigationService, strongPlateService);
        public static StrongPlateSpeedViewModel StrongPlateSpeedViewModel
        {
            get { return strongPlateSpeedViewModel; }
        }

        private static StrongPlateSteadynessViewModel strongPlateSteadynessViewModel = new StrongPlateSteadynessViewModel(frameNavigationService, strongPlateService);
        public static StrongPlateSteadynessViewModel StrongPlateSteadynessViewModel
        {
            get { return strongPlateSteadynessViewModel; }
        }
    }
}

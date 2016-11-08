using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StrongPlate.App.Services
{
    public class FrameNavigationService : IFrameNavigation
    {
        Frame currentFrame = (Frame) Window.Current.Content;
        public void NavigateToFrame(Type frameType)
        {
            currentFrame.Navigate(frameType);
        }

        public void NavigateBack()
        {
            currentFrame.GoBack();
        }
    }
}

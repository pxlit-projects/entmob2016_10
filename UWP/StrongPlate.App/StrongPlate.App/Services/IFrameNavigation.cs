using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.App.Services
{
    public interface IFrameNavigation
    {
        void NavigateToFrame(Type frameType);
        void NavigateBack();
    }
}

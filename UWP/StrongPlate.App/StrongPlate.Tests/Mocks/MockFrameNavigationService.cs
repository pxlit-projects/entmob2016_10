using StrongPlate.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPlate.Tests.Mocks
{
    class MockFrameNavigationService : IFrameNavigationService
    {
        public void NavigateBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateToFrame(Type frameType)
        {
            throw new NotImplementedException();
        }
    }
}

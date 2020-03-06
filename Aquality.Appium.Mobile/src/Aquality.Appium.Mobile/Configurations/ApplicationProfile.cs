using Aquality.Appium.Mobile.Applications;
using System;

namespace Aquality.Appium.Mobile.Configurations
{
    public class ApplicationProfile : IApplicationProfile
    {
        public IDriverSettings DriverSettings => throw new NotImplementedException();

        public bool IsRemote => throw new NotImplementedException();

        public PlatformName PlatformName => throw new NotImplementedException();

        public Uri RemoteConnectionUrl => throw new NotImplementedException();
    }
}

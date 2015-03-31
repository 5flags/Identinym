using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaSoft.MvvmLight;
using Identinym.Shell.Properties;

namespace Identinym.Shell
{
    public class MainInstaller : IWindsorInstaller
    {
        public MainInstaller()
        {
            //if this is our first time running the GUI after an upgrade then pull across settings from the previous version
            UpgradeAppConfigSettings();
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInThisApplication().BasedOn<ViewModelBase>());
        }

        private static void UpgradeAppConfigSettings()
        {
            if (Settings.Default.UpgradeSettings)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeSettings = false;
            }
        }
    }
}

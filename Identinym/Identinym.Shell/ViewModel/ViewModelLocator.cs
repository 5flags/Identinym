/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Identinym.Shell"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Identinym.Shell.Utils;
using log4net;
using Microsoft.Practices.ServiceLocation;

namespace Identinym.Shell.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
                var container = new WindsorContainer();
                container.Install(FromAssembly.This());
                
                ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoggingViewModel Logging
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoggingViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
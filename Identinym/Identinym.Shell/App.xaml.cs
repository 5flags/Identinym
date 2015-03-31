using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;

namespace Identinym.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        public App()
        {
            DispatcherUnhandledException += (sender, args) => { };
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => { };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppearanceManager.Current.ThemeSource = AppearanceManager.DarkThemeSource;
            AppearanceManager.Current.AccentColor = Color.FromRgb(0x50, 0x2D, 0x7F);
        }
    }
}

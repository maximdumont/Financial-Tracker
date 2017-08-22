using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FinTrack.Shell.Bootstrapper;
using MahApps.Metro;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Service.Global.Settings;

namespace FinTrack.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bstrap = new FinTrackBootstrapper();
            bstrap.Run();
        }
    }
}
using System.Windows;
using FinTrack.Shell.Views;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using Service.Global.Logging;

namespace FinTrack.Shell.Bootstrapper
{
    public class FinTrackBootstrapper : UnityBootstrapper, IFinTrackBoostrapper
    {
        public FinTrackBootstrapper(bool loadContainerOnLoad = true)
        {
            if (!loadContainerOnLoad) return;

            var container = new UnityContainer();
            container.LoadConfiguration();

            Container = container;
        }

        public FinTrackBootstrapper(IUnityContainer unityContainer) => Container = unityContainer;
        protected override ILoggerFacade CreateLogger() => Container.TryResolve<FinancialTrackerLogger>();
        protected override IModuleCatalog CreateModuleCatalog() => new ConfigurationModuleCatalog();

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            base.Container.AddNewExtension<Interception>();
        }

        protected override DependencyObject CreateShell() => Container.TryResolve<ShellWindow>();

        protected override void InitializeShell()
        {
            base.InitializeShell();

            var window = Application.Current.MainWindow;
            window = (Window) Shell;
            window.Show();
        }
    }
}
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Service.Global.Constants;
using Service.Global.Unity;
using UI.HeaderModule.Views;

namespace UI.HeaderModule
{
    public class HeaderModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public HeaderModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            UnityConfigurationLoader.LoadFromModule(this, container);
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(ViewNames.HeaderView,
                () => UnityConfigurationLoader.LoadedContainer.Resolve<CalendarHeader>());
        }
    }
}
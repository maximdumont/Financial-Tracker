using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Service.Global.Constants;
using Service.Global.Unity;
using UI.CalendarModule.LocalViewNames;
using UI.CalendarModule.Views;

namespace UI.CalendarModule
{
    public class CalendarModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public CalendarModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            UnityConfigurationLoader.LoadFromModule(this, unityContainer);
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(ViewNames.CalendarView,
                () => _unityContainer.Resolve<CalendarGrid>());

            _regionManager.RegisterViewWithRegion(CalendarModuleViewNames.CalendarHeaderView,
                () => _unityContainer.Resolve<CalendarDaysHeader>());

            _regionManager.RegisterViewWithRegion(CalendarModuleViewNames.CalendarUniformGridView,
                () => _unityContainer.Resolve<CalendarUniformGrid>());

            _regionManager.RegisterViewWithRegion(ViewNames.HeaderView,
                () => UnityConfigurationLoader.LoadedContainer.Resolve<CalendarHeader>());
        }
    }
}
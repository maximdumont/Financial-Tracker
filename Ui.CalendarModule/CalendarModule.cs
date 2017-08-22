using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Service.Global.Constants;
using Service.Global.Unity;
using UI.CalendarModule.ViewModels;
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

            _regionManager.RegisterViewWithRegion(LocalViewNames.CalendarModuleViewNames.CalendarHeaderView,
                () => _unityContainer.Resolve<CalendarHeader>());

            _regionManager.RegisterViewWithRegion(LocalViewNames.CalendarModuleViewNames.CalendarUniformGridView,
                () => _unityContainer.Resolve<CalendarUniformGrid>());
        }
    }
}
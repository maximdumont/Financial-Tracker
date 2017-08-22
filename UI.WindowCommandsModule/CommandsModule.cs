using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Service.Global.Constants;
using Service.Global.Unity;
using UI.WindowCommandsModule.Views;

namespace UI.WindowCommandsModule
{
    public class CommandsModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public CommandsModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            UnityConfigurationLoader.LoadFromModule(this, unityContainer);
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(ViewNames.RightWindowCommandsViewIconPanel,
                () => _unityContainer.Resolve<RightWindowCommands>());

            _regionManager.RegisterViewWithRegion(ViewNames.LeftWindowCommandsViewIconPanel,
                () => _unityContainer.Resolve<LeftWindowCommands>());
        }
    }
}
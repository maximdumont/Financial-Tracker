using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Service.Global.Constants;
using Service.Global.Events;
using Service.Global.Events.Controls;
using Service.Global.Unity;
using UI.SidePanelModule.LocalViewNames;
using UI.SidePanelModule.Views;

namespace UI.SidePanelModule
{
    public class SidePanelModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        private readonly IEventAggregator _eventAggregator;

        public SidePanelModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _eventAggregator = eventAggregator;
            UnityConfigurationLoader.LoadFromModule(this, _unityContainer);
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(ViewNames.SidePanelView,
                () => _unityContainer.TryResolve<AboutSidePane>());

            _regionManager.RegisterViewWithRegion(ViewNames.SidePanelView,
                () => _unityContainer.TryResolve<SelectedDayAccountsSidePane>());

            _regionManager.RegisterViewWithRegion(ViewNames.SidePanelView,
                () => _unityContainer.TryResolve<SettingsSidePane>());

            _eventAggregator
                .GetEvent<SetFlyoutControlEvent<string>>()
                .Subscribe(OnSetSidePanelOpenAndSendStringEventReceived);
        }

        private void OnSetSidePanelOpenAndSendStringEventReceived(string obj)
        {
            var regionManagerRegions = _regionManager.Regions[ViewNames.SidePanelView];
            var regionManagerViews = regionManagerRegions.Views;
            foreach (UserControl regionManagerView in regionManagerViews)
            {
                var type = regionManagerView.GetType();
                var typeName = type.Name;

                if (typeName.Contains(obj))
                {
                    regionManagerRegions?.Activate(regionManagerView);
                }
            }
        }
    }
}
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Service.Global.Unity;

namespace Service.Global
{
    public class GlobalModule : IModule
    {
        private readonly IUnityContainer _container;

        public GlobalModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            UnityConfigurationLoader.LoadFromModule(this, _container);
        }
    }
}
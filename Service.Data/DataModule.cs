using Microsoft.Practices.Unity;
using Prism.Modularity;
using Service.Global.Unity;

namespace Service.Data
{
    public class DataModule : IModule
    {
        public DataModule(IUnityContainer unityContainer)
        {
            UnityConfigurationLoader.LoadFromModule(this, unityContainer);
        }

        public void Initialize()
        {
        }
    }
}
using System;
using Microsoft.Practices.Unity;

namespace Service.Global.Extensions
{
    public static class UnityExtensions
    {
        public static void RegisterContainerRegistration(this IUnityContainer container,
            ContainerRegistration registration, bool overrideIfExists = false)
        {
            var registeredType = registration.RegisteredType;
            var mappedToType = registration.MappedToType;
            if (container.IsRegistered(registeredType) && !overrideIfExists)
                return;

            if (registeredType == null || mappedToType == null)
                throw new Exception("Parameters Can Not Be Null");

            container.RegisterType(registeredType, mappedToType);
        }
    }
}
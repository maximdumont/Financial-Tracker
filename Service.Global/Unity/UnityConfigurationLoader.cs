using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Prism.Modularity;
using Service.Global.Extensions;

namespace Service.Global.Unity
{
    public class UnityConfigurationLoader
    {
        private static string _entryAssembly;
        private const string ConfigurationFolderPath = "Configuration";
        private const string UnityConfigFileEnding = ".unity.config";
        private const string WildCardPath = "*";
        private const string UnitySectionName = "unity";

        public static void LoadFromModule(IModule assembly, IUnityContainer parentContainer)
        {
            if (_entryAssembly == null)
            {
                _entryAssembly = Assembly.GetEntryAssembly().Location;
            }

            var entryPath = Path.GetDirectoryName(_entryAssembly);
            var configurationPath = Path.Combine(entryPath, ConfigurationFolderPath);
            var assemblyName = assembly.GetType().Name;
            var moduleFile = (Directory.GetFiles(configurationPath,
                $"{WildCardPath}{assemblyName}{UnityConfigFileEnding}")).First();

            if (!File.Exists(moduleFile))
            {
                throw new FileNotFoundException($"{moduleFile} Not Found");
            }

            var exeConfigurationFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = moduleFile
            };

            var configuration =
                ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection) configuration.GetSection(UnitySectionName);
            var containerRegistrations =
                ((new UnityContainer().LoadConfiguration(unitySection)).Registrations).ToArray();

            if (!containerRegistrations.Any()) return;
            foreach (ContainerRegistration registration in containerRegistrations)
            {
                parentContainer.RegisterContainerRegistration(registration);
            }

            LoadedContainer = parentContainer;
        }

        public static IUnityContainer LoadedContainer { get; private set; }
    }
}
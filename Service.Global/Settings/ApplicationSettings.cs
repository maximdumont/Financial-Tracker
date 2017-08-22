using System;
using System.Collections.Generic;

namespace Service.Global.Settings
{
    public class ApplicationSettings
    {
        public const string DefaultSettingFileName = "settings.xml";

        public ApplicationSettings()
        {
            Setting = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Setting { get; }

        public void Save<T>(string name, T value)
        {
        }

        public T Read<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}
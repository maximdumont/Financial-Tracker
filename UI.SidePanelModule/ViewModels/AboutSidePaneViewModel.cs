using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using UI.SidePanelModule.ViewModels.BaseTypes;

namespace UI.SidePanelModule.ViewModels
{
    public class AboutSidePaneViewModel : BindableBase, IAboutSidePaneViewModel
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Information { get; set; }
        public string AssemblyVersion { get; set; }
        public string FileVersion { get; set; }
        public string ProductVersion { get; set; }

        public AboutSidePaneViewModel()
        {
            AssemblyVersion = "Assembly: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            FileVersion = "File Version: " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
                              .FileVersion;
            ProductVersion = "Product Version:" + FileVersionInfo
                                 .GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

            Information =
                "Welcome To FinTrack. This Application can be used to get a visual view of expenses vs income";
            Information += "This product is maintained and created by Maxim Dumont";
        }
    }
}
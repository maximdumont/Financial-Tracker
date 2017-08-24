using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Service.Global.Theming;
using UI.SidePanelModule.ViewModels.BaseTypes;

namespace UI.SidePanelModule.ViewModels
{
    public class SettingsSidePaneViewModel : BindableBase, ISettingsSidePaneViewModel
    {
        private ICommand _changeThemeCommand;
        private double _maximumDailyAllowance;
        private string _selectedThemeChoice;
        private IEnumerable<string> _themeChoices;

        public SettingsSidePaneViewModel(IUiThemeManager themeManager)
        {
            ThemeChoices = themeManager.ThemeChoices;
            ChangeThemeCommand = new DelegateCommand(() => themeManager.ToggleTo(SelectedThemeChoice));
        }

        public ICommand ChangeThemeCommand
        {
            get => _changeThemeCommand;
            set => SetProperty(ref _changeThemeCommand, value);
        }

        public IEnumerable<string> ThemeChoices
        {
            get => _themeChoices;
            set => SetProperty(ref _themeChoices, value);
        }

        public string SelectedThemeChoice
        {
            get => _selectedThemeChoice;
            set => SetProperty(ref _selectedThemeChoice, value);
        }

        public double MaximumDailyAllowance
        {
            get => _maximumDailyAllowance;
            set => SetProperty(ref _maximumDailyAllowance, value);
        }
    }
}
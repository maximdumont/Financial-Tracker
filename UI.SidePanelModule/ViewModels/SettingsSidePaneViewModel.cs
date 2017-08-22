using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Global.Theming;
using UI.SidePanelModule.ViewModels.BaseTypes;

namespace UI.SidePanelModule.ViewModels
{
    public class SettingsSidePaneViewModel : BindableBase, ISettingsSidePaneViewModel
    {
        private readonly IUiThemeManager _themeManager;
        private IEnumerable<string> _themeChoices;
        private string _selectedThemeChoice;
        private double _maximumDailyAllowance;
        private ICommand _changeThemeCommand;

        public SettingsSidePaneViewModel(IUiThemeManager themeManager)
        {
            _themeManager = themeManager;
            ThemeChoices = themeManager.ThemeChoices;
            ChangeThemeCommand = new DelegateCommand<string>(OnChangeThemeCommandClicked);
        }

        private void OnChangeThemeCommandClicked(string newTheme)
        {
            _themeManager.ToggleTo(newTheme);
            SelectedThemeChoice = newTheme;
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
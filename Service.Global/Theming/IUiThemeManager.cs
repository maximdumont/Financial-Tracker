using System.Collections.Generic;

namespace Service.Global.Theming
{
    public interface IUiThemeManager
    {
        void ToggleToDark();
        void ToggleToLight();
        void ToggleTo(string name);

        IEnumerable<string> ThemeChoices { get; }
        string CurrentAccent { get; }
        string CurrentTheme { get; }
    }
}
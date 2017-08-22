using System.Collections.Generic;
using System.Windows;
using MahApps.Metro;

namespace Service.Global.Theming
{
    public class UiThemeManager : IUiThemeManager
    {
        public void ToggleToDark()
        {
            InternalToggle("BaseDark", "Green");
        }

        public void ToggleToLight()
        {
            InternalToggle("BaseLight", "Blue");
        }

        public void ToggleTo(string name)
        {
            if (name.Equals("Dark"))
                ToggleToDark();
            else
                ToggleToLight();
        }

        public IEnumerable<string> ThemeChoices { get; } = new List<string>
        {
            "Dark",
            "Light"
        };

        public string CurrentAccent { get; private set; }
        public string CurrentTheme { get; private set; }

        private void InternalToggle(string appTheme, string accent)
        {
            ThemeManager.ChangeAppStyle(Application.Current,
                ThemeManager.GetAccent(accent),
                ThemeManager.GetAppTheme(appTheme));

            CurrentAccent = accent;
            CurrentTheme = appTheme;
        }
    }
}
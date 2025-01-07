using eTasks.Shared.Services.Interfaces;

namespace eTasks.Shared.Services
{
    public class ThemeService : IThemeService
    {
        private bool _isDark = false;

        public IThemeService ChangeTheme()
        {
            _isDark = !_isDark;
            return this;
        }

        public bool IsDarkTheme()
        {
            return _isDark;
        }

        public IThemeService SetTheme(bool isDark)
        {
            _isDark = isDark;
            return this;
        }
    }
}

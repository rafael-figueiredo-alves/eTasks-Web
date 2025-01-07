namespace eTasks.Shared.Services.Interfaces
{
    public interface IThemeService
    {
        public bool IsDarkTheme();
        public IThemeService SetTheme(bool isDark);
        public IThemeService ChangeTheme();
    }
}

namespace eTasks.Shared.Services.Interfaces
{
    public interface IThemeService
    {
        public event Func<Task>? OnThemeChanged;
        public Task<bool> IsDarkTheme();
        public Task<IThemeService> SetTheme(bool isDark);
        public Task<IThemeService> ChangeTheme();
    }
}

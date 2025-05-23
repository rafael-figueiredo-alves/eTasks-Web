﻿using eTasks.Shared.Services.Interfaces;

namespace eTasks.Shared.Services
{
    public class ThemeService : IThemeService
    {
        #region Constante e Variáveis privadas
        const string ThemeStorageKey = "ThemeIsDark";

        private bool _isDark = false;

        private LocalStorage LocalStorage { get; set; }
        #endregion

        #region Métodos
        public event Func<Task>? OnThemeChanged = null;

        public ThemeService(LocalStorage localStorage)
        {
            LocalStorage = localStorage;
        }

        private async Task CallOnThemeChangedEvent()
        {
            if (OnThemeChanged != null)
            {
                await OnThemeChanged.Invoke();
            }
        }

        public async Task<IThemeService> ChangeTheme()
        {
            _isDark = !_isDark;

            await LocalStorage.SetValue(ThemeStorageKey, _isDark);

            await CallOnThemeChangedEvent();

            return this;
        }

        public async Task<bool> IsDarkTheme()
        {
            if(!await LocalStorage.KeyExists(ThemeStorageKey))
                await LocalStorage.SetValue(ThemeStorageKey, _isDark);

            _isDark = await LocalStorage.GetValue<bool>(ThemeStorageKey);

            return _isDark;
        }

        public async Task<IThemeService> SetTheme(bool isDark)
        {
            _isDark = isDark;

            await LocalStorage.SetValue(ThemeStorageKey, _isDark);

            await CallOnThemeChangedEvent();

            return this;
        }
        #endregion
    }
}

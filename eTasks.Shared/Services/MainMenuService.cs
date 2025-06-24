using eTasks.Components.Menus;

namespace eTasks.Shared.Services
{
    public class MainMenuService
    {
        private MainMenuItemType _mainMenuItemSelected = MainMenuItemType.Home;

        public MainMenuItemType MainMenuItemSelected
        {
            get => _mainMenuItemSelected;
            set
            {
                _mainMenuItemSelected = value;
            }
        }

        public void SetSelected(MainMenuItemType itemType)
        {
            MainMenuItemSelected = itemType;
        }

        public MainMenuItemType GetSelected()
        {
            return MainMenuItemSelected;
        }

    }
}

namespace eTasks.Shared.Services
{
    public class MenuTeste
    {
        private int _menuSelected = 0;

        public int MenuSelected
        {
            get => _menuSelected;
            set
            {
                _menuSelected = value;
            }
        }

        public void SetSelected(int itemType)
        {
            MenuSelected = itemType;
        }

    }
}

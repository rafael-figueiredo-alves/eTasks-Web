using eTasks.Shared.Services.Interfaces;

namespace eTasks.Shared.Services
{
    public class ActionButtonVisibleService : IActionButtonVisibleService
    {
        private bool _visible = true;

        bool IActionButtonVisibleService.Visible { get => _visible; set => SetVisible(value); }

        public void SetVisible(bool visible)
        {
            _visible = visible;
        }
    }
}

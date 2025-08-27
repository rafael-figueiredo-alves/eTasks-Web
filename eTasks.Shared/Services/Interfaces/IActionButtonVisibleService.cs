namespace eTasks.Shared.Services.Interfaces
{
    public interface IActionButtonVisibleService
    {
        public void SetVisible(bool visible);
        public bool Visible { get; set; }
    }
}

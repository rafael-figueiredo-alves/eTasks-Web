namespace eTasks.View.Pages.OtherPages.About.Components
{
    public class Changelog
    {
        public string VersionTitle { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
    }

    public class ChangelogClass
    {
        public string Language { get; set; } = string.Empty;
        public List<Changelog> Changelog { get; set; } = new List<Changelog>();
    }
}

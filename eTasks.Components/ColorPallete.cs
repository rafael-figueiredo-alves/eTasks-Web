namespace eTasks.Components
{
    public static class ColorPallete
    {
        public static string GetColor(Cor _cor, bool isDarkMode)
        {
            switch(_cor)
            {
                case Cor.Primary:
                    return isDarkMode ? "#FFFFFF" : "#336699";
                case Cor.Secondary:
                    return isDarkMode ? "#807E7E" : "#B8CADB";
                case Cor.Background:
                    return isDarkMode ? "#212529" : "#FFFFFF";
                case Cor.FabButton:
                    return isDarkMode ? "#336699" : "#66BB6A";
                case Cor.OkButton:
                    return isDarkMode ? "#66BB6A" : "#66BB6A";
                case Cor.CancelButton:
                    return isDarkMode ? "#EE5351" : "#EE5351";
                case Cor.Shadow:
                    return isDarkMode ? "0px 2px 4px rgba(100,100,100,0.5)" : "0 4px 8px rgba(0, 0, 0, 0.2)";
                case Cor.Text:
                    return isDarkMode ? "#FFFFFF" : "#000000";
                default:
                    return isDarkMode ? "#FFFFFF" : "#336699";
            }
        }
    }

    public enum Cor
    {
        Primary,
        Secondary,
        Background,
        FabButton,
        OkButton,
        CancelButton,
        Shadow,
        Text
    }
}

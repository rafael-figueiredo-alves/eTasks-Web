﻿namespace eTasks.View.Pages
{
    public class AboutBase : PageBase
    {
        protected string Versao { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Versao = "2.0.0";
        }
    }
}
﻿using Microsoft.AspNetCore.Components;

namespace eTasks.Components.Bars
{
    public class AvatarBase : ComponentBase
    {
        [Inject] protected NavigationManager? navigationManager { get; set; }

        #region Parâmetros
        [Parameter] public string AvatarPath { get; set; } = string.Empty;
        [Parameter] public string OffcanvasMenuID {  get; set; } = string.Empty;
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public bool isDarkMode { get; set; } = false;
        #endregion

        protected string AvatarImagePath { get; set; } = string.Empty;

        protected override void OnParametersSet()
        {
            if(AvatarPath != string.Empty)
            {
                AvatarImagePath = AvatarPath;
            }
            else
            {
                if (isDarkMode)
                    AvatarImagePath = "assets/UI/avatar/dark/Avatar.png";
                else
                    AvatarImagePath = "assets/UI/avatar/light/Avatar.png";
            }
        }
    }
}

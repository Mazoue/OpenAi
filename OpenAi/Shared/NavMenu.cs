using Microsoft.AspNetCore.Components;

namespace OpenAi.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}

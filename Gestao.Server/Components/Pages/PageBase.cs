using Blazored.LocalStorage;
using Gestao.Database;
using Microsoft.AspNetCore.Components;


namespace Gestao.Server.Components.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorage { get; set; } = null!;
        [Inject] public AppDbContext DB { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    }
}

using CondoApp.Api.Entities;

using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class BuildingsBase : ComponentBase
    {
        [Inject]
        public IBuildingService? BuildingService { get; set; }

        public IEnumerable<Building> Buildings { get; set; } = Enumerable.Empty<Building>();

        protected override async Task OnInitializedAsync()
        {
            Buildings = await BuildingService.GetBuildings();
        }


    }
}

using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class BuildingDetailsBase : ComponentBase
    {
        [Parameter]

        public int Id { get; set; }

        [Inject]
        public IBuildingService BuildingService { get; set; }

        public BuildingDto Building { get; set; } = new BuildingDto();


        protected override async Task OnInitializedAsync()
        {
            Building = await BuildingService.GetBuildingById(Id);
        }
    }
}

using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class BuildingEditBase : ComponentBase
    {
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IBuildingService BuildingService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Building NewBuilding { get; set; } = new Building();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var buildingId = Convert.ToInt32(Id);
                NewBuilding = await BuildingService.GetBuildingById(buildingId);
            }

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id))
            {
                var res = await BuildingService.AddBuilding(NewBuilding);

                if (res != null)
                {
                    Saved = true;
                    Message = "Building has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await BuildingService.UpdateBuilding(NewBuilding);
                Saved = true;
                Message = "Building has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void GoToOverview()
        {
            navigationManager.NavigateTo("/Buildings");
        }

        protected async Task DeleteBuilding()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var buildingId = Convert.ToInt32(Id);
                await BuildingService.DeleteBuilding(buildingId);

                navigationManager.NavigateTo("/Buildings");
            }

            Message = "Something went wrong, unable to delete";
        }
    }
}

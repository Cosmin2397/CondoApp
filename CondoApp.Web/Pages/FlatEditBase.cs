using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class FlatEditBase : ComponentBase
    {
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IFlatService FlatService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Flats NewFlat { get; set; } = new Flats();

        public FlatDto NewFlatDto { get; set; } = new FlatDto();

        public double TotalCost { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var flatId = Convert.ToInt32(Id);
                NewFlat = await FlatService.GetFlatById(flatId);
                NewFlatDto = await FlatService.GetFlatDtoById(flatId);
                TotalCost = await FlatService.TotalCostByFlat(flatId);
            }

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id))
            {
                var res = await FlatService.AddFlat(NewFlat);

                if (res != null)
                {
                    Saved = true;
                    Message = "Flat has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await FlatService.UpdateFlat(NewFlat);
                Saved = true;
                Message = "Flat has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void GoToOverview()
        {
            navigationManager.NavigateTo("/Flats");
        }

        protected async Task DeleteFlat()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var flatId = Convert.ToInt32(Id);
                await FlatService.DeleteFlat(flatId);

                navigationManager.NavigateTo("/Flats");
            }

            Message = "Something went wrong, unable to delete";
        }
    }
}

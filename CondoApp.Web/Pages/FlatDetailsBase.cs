using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class FlatDetailsBase : ComponentBase
    {
        [Parameter]

        public int Id { get; set; }

        [Inject]
        public IFlatService FlatService { get; set; }

        public FlatDto FlatDto { get; set; } = new FlatDto();


        protected override async Task OnInitializedAsync()
        {
            FlatDto = await FlatService.GetFlatById(Id);
        }
    }
}

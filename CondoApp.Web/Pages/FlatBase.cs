using CondoApp.Api.Entities;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class FlatBase : ComponentBase
    {
        [Inject]
        public IFlatService? FlatService { get; set; }

        public IEnumerable<Flats> FlatsList { get; set; } = Enumerable.Empty<Flats>();

        protected override async Task OnInitializedAsync()
        {
            FlatsList = await FlatService.GetFlats();
        }
    }
}

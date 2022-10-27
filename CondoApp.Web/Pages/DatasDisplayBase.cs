
using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class DatasDisplayBase : ComponentBase
    {
        [Inject]
        public IBuildingService? BuildingService { get; set; }

        public DatasDto Datas { get; set; } = new DatasDto();

        protected override async Task OnInitializedAsync()
        {
            Datas = await BuildingService.GetDatas();
        }
    }
}

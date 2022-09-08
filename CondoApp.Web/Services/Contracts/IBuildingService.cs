using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IBuildingService
    {
        Task<IEnumerable<Building>> GetBuildings();

        Task<BuildingDto> GetBuildingById(int id);
    }
}

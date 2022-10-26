using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IBuildingService
    {
        Task<IEnumerable<Building>> GetBuildings();

        Task<BuildingDto> GetBuildingDtoById(int id);

        Task<Building> GetBuildingById(int id);

        Task<Building> AddBuilding(Building newBuilding);

        Task UpdateBuilding(Building building);

        Task DeleteBuilding(int id);

        Task<DatasDto> GetDatas();
    }
}

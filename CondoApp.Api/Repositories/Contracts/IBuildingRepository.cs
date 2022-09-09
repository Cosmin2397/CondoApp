using CondoApp.Api.Entities;

namespace CondoApp.Api.Repositories.Contracts
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<Building>> GetBuildings();

        Task<IEnumerable<Flats>> GetFlatsByBuildingId(int id);

        Task<Building> GetBuildingById(int id);

        Task<Building> AddBuilding(Building building);

        Task<Building> UpdateBuilding(int id, Building newBuilding);

        Task<Building> DeleteBuilding(int id);

    }
}

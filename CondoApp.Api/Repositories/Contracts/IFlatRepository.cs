using CondoApp.Api.Entities;

namespace CondoApp.Api.Repositories.Contracts
{
    public interface IFlatRepository
    {
        Task<IEnumerable<Flats>> GetFlats();

        Task<IEnumerable<Expense>> GetExpensesByFlatId(int id);

        Task<Building> GetBuildingOfFlat(int buildingID);

        Task<Flats> GetFlatById(int id);
    }
}

using CondoApp.Api.Data;
using CondoApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoApp.Api.Repositories.Contracts
{
    public class FlatRepository : IFlatRepository
    {
        private readonly AppDbContext context;

        public FlatRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Building> GetBuildingOfFlat(int buildingID)
        {
            var building = await this.context.Buildings.FirstOrDefaultAsync(x => x.Id == buildingID);
            return building;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByFlatId(int id)
        {
            var expenses = await this.context.Expenses.Where(x => x.FlatId == id).ToListAsync();
            return expenses;
        }

        public async Task<Flats> GetFlatById(int id)
        {
            var flat = await this.context.Flats.FirstOrDefaultAsync(x => x.Id == id);
            return flat;
        }

        public async Task<IEnumerable<Flats>> GetFlats()
        {
            var flats = await this.context.Flats.ToListAsync();
            return flats;
        }
    }
}

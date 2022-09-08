using CondoApp.Api.Data;
using CondoApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoApp.Api.Repositories.Contracts
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly AppDbContext context;

        public BuildingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Building> GetBuildingById(int id)
        {
            var building = await this.context.Buildings.FirstOrDefaultAsync(x => x.Id == id);
            return building;
        }

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            var buildings = await this.context.Buildings.ToListAsync();
            return buildings;
        }

        public async Task<IEnumerable<Flats>> GetFlatsByBuildingId(int id)
        {
            var flats = await this.context.Flats.Where(x => x.BuildingID == id).ToListAsync();
            return flats;
        }
    }
}

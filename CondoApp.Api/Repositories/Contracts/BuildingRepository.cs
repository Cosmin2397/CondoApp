using CondoApp.Api.Data;
using CondoApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Building> AddBuilding(Building building)
        {
            if(building == null)
            {
                return null;
            }
            else
            {
                await this.context.AddAsync(building);
                await this.context.SaveChangesAsync();
                return building;
            }
        }

        public async Task<Building> DeleteBuilding(int id)
        {
            var building = await this.context.Buildings.FindAsync(id);
            if (building != null)
            {
                this.context.Buildings.Remove(building);
                await this.context.SaveChangesAsync();
            }
            return building;
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

        public async Task<Building> UpdateBuilding(int id, Building newBuilding)
        {
            var building = await this.context.Buildings.FindAsync(id);

            if (building != null)
            {
                building.Name = newBuilding.Name;
                building.Description = newBuilding.Description;
                building.PictureURL = newBuilding.PictureURL;
                building.NumOfFloors = newBuilding.NumOfFloors;
                building.NumOfFlats = newBuilding.NumOfFlats;
                building.City = newBuilding.City;
                building.Country = newBuilding.Country;
                building.Address = newBuilding.Address;

                await this.context.SaveChangesAsync();
                return building;
            }

            return null;
        }
    }
}

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

        public async Task<Flats> AddFlat(Flats newFlat)
        {
            if (newFlat == null)
            {
                return null;
            }
            else
            {
                await this.context.AddAsync(newFlat);
                await this.context.SaveChangesAsync();
                return newFlat;
            }
        }

        public async Task<Flats> DeleteFlat(int id)
        {
            var flat = await this.context.Flats.FindAsync(id);
            if (flat != null)
            {
                this.context.Flats.Remove(flat);
                await this.context.SaveChangesAsync();
            }
            return flat;
        }

        public async Task<Flats> UpdateFlat(int id, Flats newFlat)
        {
            var flat = await this.context.Flats.FindAsync(id);

            if (flat != null)
            {
                flat.Name = newFlat.Name;
                flat.Description = newFlat.Description;
                flat.PictureURL = newFlat.PictureURL;
                flat.FlatNum = newFlat.FlatNum;
                flat.Surface = newFlat.Surface;
                flat.NumOfRooms = newFlat.NumOfRooms;
                flat.Floor = newFlat.Floor;
                flat.RentingPrice = newFlat.RentingPrice;
                flat.IsRented = newFlat.IsRented;
                flat.BuildingID = newFlat.BuildingID;

                await this.context.SaveChangesAsync();
                return flat;
            }

            return null;
        }
    }
}

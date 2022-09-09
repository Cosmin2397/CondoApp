using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using System.Linq;

namespace CondoApp.Api.Extensions
{
    public static class DtoConversions
    {
        public static BuildingDto ConvertToDto(this Building building, IEnumerable<Flats> flats)
        {
            return new BuildingDto
            {
                Id = building.Id,
                PictureURL = building.PictureURL,
                Name = building.Name,
                Country = building.Country,
                City = building.City,
                Address = building.Address,
                Description = building.Description,
                NumOfFlats = building.NumOfFlats,
                NumOfFloors = building.NumOfFloors,
                FlatsOfBuilding = flats
            };
        }

        public static FlatDto ConvertFlatToDto(this Flats flat, Building building, IEnumerable<Expense> expenses)
        {
            return new FlatDto
            {
                Id= flat.Id,
                Name = flat.Name,
                Description = flat.Description,
                PictureURL= flat.PictureURL,
                FlatNum = flat.FlatNum,
                Surface = flat.Surface,
                NumOfRooms = flat.NumOfRooms,
                Floor = flat.Floor,
                RentingPrice = flat.RentingPrice,
                IsRented = flat.IsRented,
                BuildingID = flat.BuildingID,
                BuildingName = building.Name,
                BuildingCity = building.City + ", " + building.Country,
                BuildingAddress = building.Address,
                Expenses = expenses

            };
        }

        public static IEnumerable<ExpenseDto> ConvertExpensesToDto(this IEnumerable<Expense> expenses, IEnumerable<Flats> flats)
        {
            return (from expense in expenses
                    join flat in flats
                    on expense.FlatId equals flat.Id
                    select new ExpenseDto
            {
                Id = expense.Id,
                Date = expense.Date,
                ExpenseType = expense.ExpenseType,
                Name = expense.Name,
                Description= expense.Description,
                Cost = expense.Cost,
                FlatId = expense.FlatId,
                FlatName = flat.Name
            }).ToList();
        }
    }
          
}

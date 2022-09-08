using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

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
    }
          
}

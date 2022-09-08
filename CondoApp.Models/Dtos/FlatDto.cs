using CondoApp.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoApp.Models.Dtos
{
    public class FlatDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string PictureURL { get; set; } = string.Empty;

        public int FlatNum { get; set; }

        public int Surface { get; set; }

        public int NumOfRooms { get; set; }

        public int Floor { get; set; }

        public int RentingPrice { get; set; }

        public bool IsRented { get; set; }

        public int BuildingID { get; set; }

        public string BuildingName { get; set; } = String.Empty;

        public string BuildingCity { get; set; } = String.Empty;

        public string BuildingAddress { get; set; } = String.Empty;

        public IEnumerable<Expense> Expenses { get; set; } = Enumerable.Empty<Expense>();
    }
}

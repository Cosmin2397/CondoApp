using CondoApp.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoApp.Models.Dtos
{
    public class BuildingDto
    {
        public int Id { get; set; }

        public string PictureURL { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int NumOfFlats { get; set; }

        public int NumOfFloors { get; set; }

        public IEnumerable<Flats> FlatsOfBuilding { get; set; } = Enumerable.Empty<Flats>();
    }
}

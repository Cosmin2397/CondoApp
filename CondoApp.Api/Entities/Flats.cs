namespace CondoApp.Api.Entities
{
    public class Flats
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
    }
}

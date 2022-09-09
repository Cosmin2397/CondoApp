using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IFlatService
    {
        Task<IEnumerable<Flats>> GetFlats();

        Task<FlatDto> GetFlatDtoById(int id);

        Task<Flats> GetFlatById(int id);

        Task<Flats> AddFlat(Flats newFlat);

        Task UpdateFlat(Flats flat);

        Task DeleteFlat(int id);
    }
}

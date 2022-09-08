using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IFlatService
    {
        Task<IEnumerable<Flats>> GetFlats();

        Task<FlatDto> GetFlatById(int id);
    }
}

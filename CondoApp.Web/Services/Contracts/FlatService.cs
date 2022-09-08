using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using System.Net.Http.Json;

namespace CondoApp.Web.Services.Contracts
{
    public class FlatService : IFlatService
    {
        private readonly HttpClient http;

        public FlatService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<FlatDto> GetFlatById(int id)
        {
            try
            {
                var response = await this.http.GetAsync($"api/Flats/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FlatDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FlatDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public async Task<IEnumerable<Flats>> GetFlats()
        {
            try
            {
                var flats = await this.http.GetFromJsonAsync<List<Flats>>("api/Flats/");
                return flats;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using System.Net.Http.Json;

namespace CondoApp.Web.Services.Contracts
{
    public class BuildingService : IBuildingService
    {
        private readonly HttpClient _htpp;

        public BuildingService(HttpClient htpp)
        {
            _htpp = htpp;
        }

        public async Task<BuildingDto> GetBuildingById(int id)
        {
            try
            {
                var response = await _htpp.GetAsync($"api/Buildings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(BuildingDto);
                    }

                    return await response.Content.ReadFromJsonAsync<BuildingDto>();
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

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            try
            {
                var buildings = await _htpp.GetFromJsonAsync<List<Building>>("api/Buildings/");
                return buildings;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

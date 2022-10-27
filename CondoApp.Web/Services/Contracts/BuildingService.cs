using CondoApp.Api.Entities;

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public class BuildingService : IBuildingService
    {
        private readonly HttpClient _htpp;

        public BuildingService(HttpClient htpp)
        {
            _htpp = htpp;
        }

        public async Task<BuildingDto> GetBuildingDtoById(int id)
        {
            try
            {
                var response = await _htpp.GetAsync($"api/Buildings/dto/{id}");

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

        public async Task<Building> GetBuildingById(int id)
        {
            try
            {
                var response = await _htpp.GetAsync($"api/Buildings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Building);
                    }

                    return await response.Content.ReadFromJsonAsync<Building>();
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

        public async Task<Building> AddBuilding(Building newBuilding)
        {
            try
            {
                var response = await _htpp.PostAsJsonAsync<Building>("api/Buildings", newBuilding);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Building);
                    }

                    return await response.Content.ReadFromJsonAsync<Building>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteBuilding(int id)
        {
            try
            {
                await _htpp.DeleteAsync($"api/Buildings/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateBuilding(Building building)
        {
            try
            {
                var buildingJson = new StringContent(JsonSerializer.Serialize(building), Encoding.UTF8, "application/json");

                var url = $"api/Buildings/{building.Id}";

                var response = await _htpp.PutAsync(url, buildingJson);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<DatasDto> GetDatas()
        {
            try
            {
                var buildings = await _htpp.GetFromJsonAsync<List<Building>>("api/Buildings/");
                var flats = await _htpp.GetFromJsonAsync<List<Flats>>("api/Flats/");
                var expenses = await _htpp.GetFromJsonAsync<List<Expense>>("api/Expenses/");
                var datas = new DatasDto();
                foreach (var item in buildings)
                {
                    datas.NumOfBuildings++;
                }
                foreach(var item in flats)
                {
                    datas.NumOfFlats++;
                    datas.NumsOfSquareMeters += item.Surface;
                    if(item.IsRented)
                    {
                        datas.TotalRentings += item.RentingPrice;
                    }
                }
                foreach(var item in expenses)
                {
                    datas.NumOfExpenses++;
                    datas.TotalCosts += item.Cost;
                }
                return datas;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

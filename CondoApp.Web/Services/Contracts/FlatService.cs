using CondoApp.Api.Entities;

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public class FlatService : IFlatService
    {
        private readonly HttpClient http;

        public FlatService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<FlatDto> GetFlatDtoById(int id)
        {
            try
            {
                var response = await this.http.GetAsync($"api/Flats/Dto/{id}");

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

        public async Task<Flats> GetFlatById(int id)
        {
            try
            {
                var response = await this.http.GetAsync($"api/Flats/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Flats);
                    }

                    return await response.Content.ReadFromJsonAsync<Flats>();
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

        public async Task<Flats> AddFlat(Flats newFlat)
        {
            try
            {
                var response = await this.http.PostAsJsonAsync<Flats>("api/Flats", newFlat);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Flats);
                    }

                    return await response.Content.ReadFromJsonAsync<Flats>();

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

        public async Task DeleteFlat(int id)
        {
            try
            {
                await this.http.DeleteAsync($"api/Flats/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateFlat(Flats flat)
        {
            try
            {
                var flatJson = new StringContent(JsonSerializer.Serialize(flat), Encoding.UTF8, "application/json");

                var url = $"api/Flats/{flat.Id}";

                var response = await this.http.PutAsync(url, flatJson);

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

        public async Task<double> TotalCostByFlat(int id)
        {
            var total = 0;
            var flatJson = await this.http.GetAsync($"api/Flats/Dto/{id}");
            var flat = await flatJson.Content.ReadFromJsonAsync<FlatDto>();
            foreach(var item in flat.Expenses)
            {
                total += item.Cost;
            }
            return total;
        }
    }
}

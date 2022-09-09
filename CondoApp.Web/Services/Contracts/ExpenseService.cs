using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using System.Net.Http.Json;

namespace CondoApp.Web.Services.Contracts
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient http;

        public ExpenseService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            try
            {
                var response = await this.http.GetAsync($"api/Expenses/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Expense);
                    }

                    return await response.Content.ReadFromJsonAsync<Expense>();
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

        public async Task<IEnumerable<ExpenseDto>> GetExpenses()
        {
            try
            {
                var expenses = await this.http.GetFromJsonAsync<List<ExpenseDto>>("api/Expenses/");
                return expenses;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

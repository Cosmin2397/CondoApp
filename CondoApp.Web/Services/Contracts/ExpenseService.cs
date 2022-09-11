using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

        public async Task<Expense> AddExpense(Expense newExpense)
        {
            try
            {
                var response = await this.http.PostAsJsonAsync<Expense>("api/Expenses", newExpense);

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
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteExpense(int id)
        {
            try
            {
                await this.http.DeleteAsync($"api/Expenses/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateExpense(Expense expense)
        {
            try
            {
                var expenseJson = new StringContent(JsonSerializer.Serialize(expense), Encoding.UTF8, "application/json");

                var url = $"api/Expenses/{expense.Id}";

                var response = await this.http.PutAsync(url, expenseJson);

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

        public async Task<double> TotalCost()
        {
            var totalCost = 0;
            var expenses = await this.http.GetFromJsonAsync<List<ExpenseDto>>("api/Expenses/");
            foreach (var item in expenses)
            {
                totalCost += item.Cost;
            }
            return totalCost;
        }
    }
}

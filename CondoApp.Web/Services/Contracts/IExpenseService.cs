using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetExpenses();

        Task<Expense> GetExpenseById(int id);

        Task<Expense> AddExpense(Expense newExpense);

        Task UpdateExpense(Expense expense);

        Task DeleteExpense(int id);

        Task<double> TotalCost();
    }
}

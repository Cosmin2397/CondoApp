using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Services.Contracts
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetExpenses();

        Task<Expense> GetExpenseById(int id);
    }
}

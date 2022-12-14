using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;

namespace CondoApp.Api.Repositories.Contracts
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpenses();

        Task<Flats> GetFlatFromExpense(int flatID);

        Task<Expense> GetExpenseById(int id);

        Task<Expense> AddExpense(Expense expense);

        Task<Expense> UpdateExpense(int id, Expense newExpense);

        Task<Expense> DeleteExpense(int id);
    }
}

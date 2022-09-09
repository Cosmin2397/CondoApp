using CondoApp.Api.Data;
using CondoApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoApp.Api.Repositories.Contracts
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext context;

        public ExpenseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            var expense = await this.context.Expenses.FirstOrDefaultAsync(c => c.Id == id);
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            var expenses = await this.context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task<Flats> GetFlatFromExpense(int flatID)
        {
            var flat = await this.context.Flats.FirstOrDefaultAsync(c => c.Id == flatID);
            return flat;
        }
    }
}

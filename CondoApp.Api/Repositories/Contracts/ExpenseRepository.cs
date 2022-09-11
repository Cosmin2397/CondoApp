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

        public async Task<Expense> AddExpense(Expense newExpense)
        {
            if (newExpense == null)
            {
                return null;
            }
            else
            {
                await this.context.AddAsync(newExpense);
                await this.context.SaveChangesAsync();
                return newExpense;
            }
        }

        public async Task<Expense> DeleteExpense(int id)
        {
            var expense = await this.context.Expenses.FindAsync(id);
            if (expense != null)
            {
                this.context.Expenses.Remove(expense);
                await this.context.SaveChangesAsync();
            }
            return expense;
        }

        public async Task<Expense> UpdateExpense(int id, Expense newExpense)
        {
            var expense = await this.context.Expenses.FindAsync(id);

            if (expense != null)
            {
                expense.Name = newExpense.Name;
                expense.Date = newExpense.Date;
                expense.ExpenseType = newExpense.ExpenseType;
                expense.Description = newExpense.Description;
                expense.Cost = newExpense.Cost;
                expense.FlatId = newExpense.FlatId;

                await this.context.SaveChangesAsync();
                return expense;
            }

            return null;
        }
    }
}

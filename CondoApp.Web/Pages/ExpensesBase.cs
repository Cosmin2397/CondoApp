using CondoApp.Api.Entities;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using CondoApp.Models.Dtos;

namespace CondoApp.Web.Pages
{
    public class ExpensesBase : ComponentBase
    {
        [Inject]
        public IExpenseService ExpenseService { get; set; }

        public IEnumerable<ExpenseDto> Expenses { get; set; } = Enumerable.Empty<ExpenseDto>();

        public double TotalCost { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Expenses = await ExpenseService.GetExpenses();
            TotalCost = await ExpenseService.TotalCost();
        }
    }
}

using CondoApp.Api.Entities;
using CondoApp.Models.Dtos;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class ExpensesBase : ComponentBase
    {
        [Inject]
        public IExpenseService ExpenseService { get; set; }

        public IEnumerable<ExpenseDto> Expenses { get; set; } = Enumerable.Empty<ExpenseDto>();

        protected override async Task OnInitializedAsync()
        {
            Expenses = await ExpenseService.GetExpenses();
        }
    }
}

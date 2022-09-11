using CondoApp.Api.Entities;
using CondoApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CondoApp.Web.Pages
{
    public class ExpenseEditBase : ComponentBase
    {
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IExpenseService ExpenseService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Expense NewExpense { get; set; } = new Expense();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (!String.IsNullOrEmpty(Id))
            {
                var expenseId = Convert.ToInt32(Id);
                NewExpense = await ExpenseService.GetExpenseById(expenseId);
            }

        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(Id))
            {
                var res = await ExpenseService.AddExpense(NewExpense);

                if (res != null)
                {
                    Saved = true;
                    Message = "Expense has been added";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await ExpenseService.UpdateExpense(NewExpense);
                Saved = true;
                Message = "Expense has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void GoToOverview()
        {
            navigationManager.NavigateTo("/Expenses");
        }

        protected async Task DeleteExpenses()
        {
            if (!String.IsNullOrEmpty(Id))
            {
                var expenseId = Convert.ToInt32(Id);
                await ExpenseService.DeleteExpense(expenseId);

                navigationManager.NavigateTo("/Expenses");
            }

            Message = "Something went wrong, unable to delete";
        }
    }
}

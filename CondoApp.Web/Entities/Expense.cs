using CondoApp.Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondoApp.Api.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ExpensesType ExpenseType { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Cost { get; set; }

        public int FlatId { get; set; }
    }
}

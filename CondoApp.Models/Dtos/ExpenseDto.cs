using CondoApp.Api.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoApp.Models.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ExpensesType ExpenseType { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Cost { get; set; }

        public int FlatId { get; set; }

        public string FlatName { get; set; } = string.Empty;
    }
}

using CondoApp.Api.Entities;
using CondoApp.Api.Extensions;
using CondoApp.Api.Repositories.Contracts;
using CondoApp.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CondoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IFlatRepository flatRepository;

        public ExpensesController(IExpenseRepository expenseRepository, IFlatRepository flatRepository)
        {
            this.expenseRepository = expenseRepository;
            this.flatRepository = flatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            try
            {
                var expenses = await this.expenseRepository.GetExpenses();
                var flats = await this.flatRepository.GetFlats();

                if (expenses == null)
                {
                    return NotFound();
                }
                else
                {
                    var expensesDto = expenses.ConvertExpensesToDto(flats);
                    return Ok(expensesDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Expense>> GetExpenseById(int id)
        {
            try
            {
                var expense = await this.expenseRepository.GetExpenseById(id);


                if (expense == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(expense);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }
    }
}

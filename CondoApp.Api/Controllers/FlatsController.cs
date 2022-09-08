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
    public class FlatsController : ControllerBase
    {
        private readonly IFlatRepository flatRepository;

        public FlatsController(IFlatRepository flatRepository)
        {
            this.flatRepository = flatRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flats>>> GetFlats()
        {
            try
            {
                var flats = await this.flatRepository.GetFlats();

                if (flats == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(flats);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FlatDto>> GetFlatById(int id)
        {
            try
            {
                var flat = await this.flatRepository.GetFlatById(id);
                var expenses = await this.flatRepository.GetExpensesByFlatId(id);
                var building = await this.flatRepository.GetBuildingOfFlat(flat.BuildingID);
                

                if (building == null)
                {
                    return BadRequest();
                }
                else
                {

                    var flatDto = flat.ConvertFlatToDto(building, expenses);

                    return Ok(flatDto);
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

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

        [HttpGet("Dto/{id:int}")]
        public async Task<ActionResult<FlatDto>> GetFlatDtoById(int id)
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Flats>> GetFlatById(int id)
        {
            try
            {
                var flat = await this.flatRepository.GetFlatById(id);

                if (flat == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(flat);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }

        [HttpPost]
        public async Task<ActionResult<Flats>> AddFlats(Flats flat)
        {
            return Ok(flatRepository.AddFlat(flat));
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Flats>> UpdateFlat(int id, Flats newFlat)
        {
            try
            {
                var flat = await this.flatRepository.UpdateFlat(id, newFlat);
                if (flat == null)
                {
                    return NotFound();
                }

                var flatUpdated = await flatRepository.GetFlatById(flat.Id);


                return Ok(flatUpdated);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFlat(int id)
        {
            try
            {
                var flat = await this.flatRepository.DeleteFlat(id);
                if (flat == null)
                {
                    return NotFound();
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}

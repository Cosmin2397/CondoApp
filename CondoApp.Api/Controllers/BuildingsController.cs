using CondoApp.Models.Dtos;
using CondoApp.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CondoApp.Api.Entities;
using CondoApp.Api.Extensions;

namespace CondoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepository buildingRepository;

        public BuildingsController(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
            try
            {
                var buildings = await this.buildingRepository.GetBuildings();

                if(buildings == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(buildings);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuildingDto>> GetBuildingById(int id)
        {
            try
            {
                var building = await this.buildingRepository.GetBuildingById(id);
                var flats = await this.buildingRepository.GetFlatsByBuildingId(id);

                if (building == null)
                {
                    return BadRequest();
                }
                else
                {

                    var buildingDto = building.ConvertToDto(flats);

                    return Ok(buildingDto);
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

namespace BasicWebApi.App.Controllers
{
    using BasicWebApi.DTOs.CompanyDTOs;
    using BasicWebApi.DTOs.CountryDTOs;
    using BasicWebApi.Services.Implementations;
    using BasicWebApi.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService _countryService)
        {
            this._countryService = _countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDTO>>> GetAll()
        {
            try
            {
                return Ok(await _countryService.GetAllCountriesAsync());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetSingleCountry(int id)
        {
            try
            {
                if(id < 0)
                    return BadRequest("Invalid input.Please try again!");

                CountryDTO countryDTO = await _countryService.GetCountryByIdAsync(id);

                if(countryDTO == null)
                    return NotFound($"Country with id:{id} not found");

                return Ok(countryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCountry([FromBody] CreateCountryDTO createCountryDTO)
        {
            try
            {
                if (createCountryDTO == null)
                    return BadRequest("The country can not be null.Please try again!");

                if (string.IsNullOrEmpty(createCountryDTO.CountryName))
                    return BadRequest("Please fill all of the parameters!");

                await _countryService.CreateCountryAsync(createCountryDTO);

                return StatusCode(StatusCodes.Status201Created, $"Country with name:{createCountryDTO.CountryName} is created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditCountry([FromBody] EditCountryDTO editCountryDTO)
        {
            try
            {
                if (editCountryDTO == null)
                    return BadRequest("Invalid input");

                if (editCountryDTO.Id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                await _countryService.EditCountryAsync(editCountryDTO);

                return Ok("Country successfully updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                CountryDTO countryDTO = await _countryService.GetCountryByIdAsync(id);

                if (countryDTO == null)
                    return NotFound("Country not found!");

                await _countryService.DeleteCountryAsync(countryDTO.Id);

                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }
    }
}

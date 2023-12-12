namespace BasicWebApi.App.Controllers
{
    using BasicWebApi.DTOs.CompanyDTOs;
    using BasicWebApi.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService _companyService)
        {
            this._companyService = _companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> GetAll()
        {
            try
            {
                return Ok(await _companyService.GetAllCompaniesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetSingleCompany(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Invalid input.Please try again!");

                CompanyDTO companyDTO = await _companyService.GetCompanyByIdAsync(id);

                if (companyDTO == null)
                    return NotFound($"Company with id:{id} not found");

                return Ok(companyDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyDTO createCompanyDTO)
        {
            try
            {
                if (createCompanyDTO == null)
                    return BadRequest("The company can not be null.Please try again!");

                if (string.IsNullOrEmpty(createCompanyDTO.CompanyName))
                    return BadRequest("Please fill all of the parameters!");

                await _companyService.CreateCompanyAsync(createCompanyDTO);

                return StatusCode(StatusCodes.Status201Created, $"Company with name:{createCompanyDTO.CompanyName} is created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        // NOT WORKING
        [HttpPatch]
        public async Task<IActionResult> EditCompany([FromBody] EditCompanyDTO editCompanyDTO)
        {
            try
            {
                if (editCompanyDTO == null)
                    return BadRequest("Invalid input");

                if (editCompanyDTO.Id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                await _companyService.EditCompanyAsync(editCompanyDTO);

                return Ok("Company successfully updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                CompanyDTO companyDTO = await _companyService.GetCompanyByIdAsync(id);

                if(companyDTO == null)
                    return NotFound("Company not found!");

                await _companyService.DeleteCompany(companyDTO.Id);

                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }
    }
}

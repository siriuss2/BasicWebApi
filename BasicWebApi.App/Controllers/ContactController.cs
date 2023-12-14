namespace BasicWebApi.App.Controllers
{
    using BasicWebApi.DTOs.CompanyDTOs;
    using BasicWebApi.DTOs.ContactDTOs;
    using BasicWebApi.Services.Implementations;
    using BasicWebApi.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService _contactService)
        {
            this._contactService = _contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDTO>>> GetAll()
        {
            try
            {
                return Ok(await _contactService.GetAllContactsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetSingleContact(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Invalid input.Please try again!");

                ContactDTO contactDTO = await _contactService.GetContactByIdAsync(id);

                if (contactDTO == null)
                    return NotFound($"Contact with id:{id} not found");

                return Ok(contactDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] CreateContactDTO createContactDTO)
        {
            try
            {
                if (createContactDTO == null)
                    return BadRequest("The contact can not be null.Please try again!");

                if (string.IsNullOrEmpty(createContactDTO.ContactName) || createContactDTO.CompanyId <= 0 || createContactDTO.CountryId <= 0)
                    return BadRequest("Please fill all of the parameters!");

                await _contactService.CreateContactAsync(createContactDTO);

                return StatusCode(StatusCodes.Status201Created, $"Contact:{createContactDTO.ContactName} is created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditContact([FromBody] EditContactDTO editContactDTO)
        {
            try
            {
                if (editContactDTO == null)
                    return BadRequest("Invalid input");

                if (editContactDTO.Id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                await _contactService.EditContactAsync(editContactDTO);

                return Ok("Contact successfully updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                ContactDTO contactDTO = await _contactService.GetContactByIdAsync(id);

                if (contactDTO == null)
                    return NotFound("Contact not found!");

                await _contactService.DeleteContactAsync(contactDTO.Id);

                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Invalid input.Please try again!");
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<ContactWithCompanyAndCountryDTO>>> FilterContacts(int? countryId, int? companyId)
        {
            return await _contactService.FilterContacts(countryId, companyId);
        }
    }
}

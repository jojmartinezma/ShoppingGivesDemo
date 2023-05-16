using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testApiInterview1.Helpers;
using testApiInterview1.Models;
using testApiInterview1.Services;

namespace testApiInterview1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactServices _contactServices;
        private ApiResponse res;
        public ContactsController(IContactServices contactServices)
        {
            this._contactServices = contactServices;
            this.res = new ApiResponse();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            res = await this._contactServices.GetAll();
            return StatusCode(res.StatusCode, res);
        }

        [HttpGet("getContact/{email}")]
        public async Task<IActionResult> GetContact([FromRoute] string email)
        {
            res = await this._contactServices.Get(email);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPost("createContact")]
        public async Task<IActionResult> CreateContact([FromBody] Contactcs contact)
        {
            res = await this._contactServices.CreateContact(contact);
            return StatusCode(res.StatusCode, res);
        }

        [HttpPut("UpdateContact/{email}")]
        public async Task<IActionResult> CreateContact([FromRoute] string email, [FromBody] Contactcs contact)
        {
            contact.Email = email;
            res = await this._contactServices.update(contact);
            return StatusCode(res.StatusCode, res);
        }



        [HttpDelete("deleteContact/{email}")]
        public async Task<IActionResult> CreateContact([FromRoute] string email)
        {
            res = await this._contactServices.delete(email);
            return StatusCode(res.StatusCode, res);
        }


    }
}

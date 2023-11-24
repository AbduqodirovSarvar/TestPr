using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheaterForeCast.Entities;
using WheaterForeCast.Services;

namespace WheaterForeCast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices services;

        public UserController(UserServices services)
        {
            this.services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            return Ok(await services.AddUser(user));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await services.GetAllUser());
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            return Ok(await services.DeleteUser(guid));
        }


    }
}

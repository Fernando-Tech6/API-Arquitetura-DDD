using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]  // Especifico o controller sem precisar passar o nome da controller
    [ApiController]
    public class Users : ControllerBase
    {
        /*FromServices para fazer a requição de um serviço(No caso a interface que criamos)*/
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //return 400
            }

            try
            {
                var get = await service.GetAll();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Não Emncontrado" });
            }
        }
    }
}

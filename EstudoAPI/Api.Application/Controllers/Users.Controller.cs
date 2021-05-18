using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]  // Especifico o controller sem precisar passar o nome da controller
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            /*FromServices para fazer a requição de um serviço 
             ([FromServices] IUserService service) passando direto como parametro da Action.
             Porém o Melhor metodo é criando inserindo direto no construtor.*/
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //return 400
            }

            try
            {
                var get = await _service.GetAll();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }

        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]  //Com o name essa rota pode ser chamada assim.
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var get = await _service.GetAll();
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }

        }
    }
}

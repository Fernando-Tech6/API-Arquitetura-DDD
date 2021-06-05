using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
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
                var get = await _service.Get(id);
                return Ok(get);
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }

        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Post([FromBody] UserDtoCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var post = await _service.Post(user);
                if (post != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = post.Id })), post);
                }
                else
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { msg = "Não Encontrado" });
                }
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }

        [HttpPatch]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Patch([FromBody] UserDtoUpdate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var patch = await _service.Patch(user);
                if (patch != null)
                {
                    return Ok(patch);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Delet(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var delete = await _service.Delete(id);
                return Ok();
            }
            catch (ArgumentException)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { msg = "Não Encontrado" });
            }
        }
    }
}

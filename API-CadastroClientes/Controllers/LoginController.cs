
using API_CadastroClientes.DTO;
using API_CadastroClientes.MODELS.Entities.Usuarios;
using API_CadastroClientes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariosRepository repos;
        public LoginController(IUsuariosRepository _repos)
        {
            repos = _repos;
        }   
      [HttpGet]
      public IActionResult Get([FromRoute]Login login)
        {

            return Ok(login);
        }
    }


}

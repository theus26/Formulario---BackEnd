using API_CadastroClientes.MODELS;
using Microsoft.AspNetCore.Mvc;

namespace API_CadastroClientes.Controllers
{
  [Route ("api/[controller]")]
  [ApiController]
    public class CadastroController : Controller
    {
        [HttpPost]
        public IActionResult Post(Usuarios user)
        {
            return Ok (user);
        }
    }
}

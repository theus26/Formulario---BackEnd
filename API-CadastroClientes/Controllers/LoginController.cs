
using API_CadastroClientes.DTO;
using API_CadastroClientes.MODELS;
using API_CadastroClientes.MODELS.Entities.Usuarios;
using API_CadastroClientes.Repositories;
using API_CadastroClientes.Services;
using API_CadastroClientes.Utils;
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
        [HttpPost]
        public IActionResult EfetuarLogin(PostUser login)
        {
          
              
                
            try
            {
                if(login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrWhiteSpace(login.Email) 
                 || string.IsNullOrEmpty(login.Senha) || string.IsNullOrWhiteSpace(login.Senha)){
                    return BadRequest(new RespostaErrorDTO()
                    {
                        Status = StatusCodes.Status404NotFound,
                        Errorr = "Login ou Senha Incorretos"
                    });
                }
                var usuarioTeste = new Usuarios()
                {
                   // Id = login.Id,
                    //Name = login.Name,
                    Email = login.Email,
                   // Senha = login.Senha,
                };

                var token = TokenService.criarToken(usuarioTeste);
                if (repos.Senha (MD5Helper.GerarHashMd5(login.Senha)) && repos.ExisteUserpeloEmail(login.Email))
                {
                    return Ok(new LoginRespostaDTO()
                    {
                        msg = "Usuarios Autenticados !",
                        Token = token
                    });
                   
                }
                return BadRequest("Usuarios ou senha Invalidos !");
            }
           

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Errorr = "Ocorreu erro ao Fazer Login, Tente Novamente!"
                });
            }
        }
     
    }


}

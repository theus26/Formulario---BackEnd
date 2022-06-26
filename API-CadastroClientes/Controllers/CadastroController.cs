using API_CadastroClientes.DTO;
using API_CadastroClientes.MODELS.Entities.Usuarios;
using API_CadastroClientes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace API_CadastroClientes.Controllers
{
  [Route ("api/[controller]")]
  [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly IUsuariosRepository repos;
        public CadastroController(IUsuariosRepository _repos)
        {
            repos = _repos;
        }

        [HttpPost]
        public IActionResult CadastrandoUser(PostUser user)
        {
            try
            {
                var erros = new List<string>();
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrWhiteSpace(user.Name) || user.Name.Length <= 2)
                {
                    erros.Add("Nome Inválido");
                }
                if(string.IsNullOrEmpty(user.Senha) || string.IsNullOrWhiteSpace(user.Senha) || user.Senha.Length <= 4 && Regex.IsMatch(user.Senha, "[a-zA-Z0-9]+", RegexOptions.IgnoreCase))
                {
                    erros.Add("Senha Inválida");
                }
                Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (string.IsNullOrEmpty(user.Email) || string.IsNullOrWhiteSpace(user.Email) || !regex.Match(user.Email).Success)
                {
                    erros.Add("Email Inválido");
                }
                if (erros.Count > 0)
                {
                    return BadRequest(new RespostaErrorDTO()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = "Campos Invalidos" // Depois tentar mostrar a lista de erro, ou seja refatorar esse codigo
                    });
                }
                if (repos.Create(user))
                   return Ok("Cliente Cadastrado");

                    return BadRequest();
                
                    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespostaErrorDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Error = "Ocorreu erro ao salvar usuário, Tente Novamente!"
                });
            }
        }
    }
}

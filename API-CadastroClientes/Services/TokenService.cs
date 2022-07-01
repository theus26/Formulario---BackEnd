using API_CadastroClientes.MODELS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_CadastroClientes.Services
{
    public class TokenService : Controller
    {
       public static string criarToken(Usuarios users)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chaveCriptografadaemBytes = Encoding.ASCII.GetBytes(ChaveJWT.ChaveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Sid, users.Id.ToString()),
                    new Claim(ClaimTypes.Email, users.Email),

                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografadaemBytes), SecurityAlgorithms.HmacSha256Signature)
            };
             var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

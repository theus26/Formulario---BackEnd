using API_CadastroClientes.MODELS;
using API_CadastroClientes.MODELS.Entities.Usuarios;
using API_CadastroClientes.Utils;

namespace API_CadastroClientes.Repositories
{
    public interface IUsuariosRepository
    {
        public bool Create(PostUser cliente);
        bool ExisteUserpeloEmail(string email);
         bool Senha( string senha);
    }

    public class UsuariosRepository: IUsuariosRepository
    {
        private readonly _DbContext db;

        public UsuariosRepository(_DbContext _db)
        {
              db = _db;
        }

       

        public bool Create(PostUser user)
        {
            try
            {
                var cliente_db = new Usuarios()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Senha = MD5Helper.GerarHashMd5 (user.Senha),
                };
                db.usuario.Add(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool ExisteUserpeloEmail(string email)
        {
          return db.usuario.Any(u => u.Email.ToLower() == email.ToLower());
          
        }

        public bool Senha( string senha)
        {
            return db.usuario.Any(u => u.Senha.ToLower()  == senha.ToLower());
           
        }
    }
}

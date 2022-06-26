using API_CadastroClientes.MODELS;
using API_CadastroClientes.MODELS.Entities.Usuarios;

namespace API_CadastroClientes.Repositories
{
    public interface IUsuariosRepository
    {
        public bool Create(PostUser cliente);
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
                    Senha = user.Senha,
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
    }
}

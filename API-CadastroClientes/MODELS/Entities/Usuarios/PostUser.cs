namespace API_CadastroClientes.MODELS.Entities.Usuarios
{
    public class PostUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string Senha { get; set; }
        public string Email { get; set; }
    }
}

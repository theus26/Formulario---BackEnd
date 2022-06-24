using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CadastroClientes.MODELS
{
    [Table(name: "Cadastro-de-Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Name { get; set; }
        public int Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}

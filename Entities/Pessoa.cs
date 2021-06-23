using System.ComponentModel.DataAnnotations;

namespace EFCore.Interceptors
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
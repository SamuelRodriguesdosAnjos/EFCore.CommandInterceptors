using System.Linq;

namespace EFCore.Interceptors
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();            
            db.Database.EnsureCreated();

            db.Pessoas.Add(new Pessoa {
                Nome = "João"
            });

            db.Pessoas.Add(new Pessoa {
                Nome = "Paula"
            });

            db.Pessoas.Add(new Pessoa {
                Nome = "Maya"
            });

            db.SaveChanges();

            db.Pessoas.FirstOrDefault(x => x.Nome.Contains("ya"));
        }
    }
}

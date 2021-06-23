using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Interceptors
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=localhost;Database=Teste-01;Integrated Security=True;")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
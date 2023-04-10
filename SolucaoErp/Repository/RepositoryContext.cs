using Microsoft.EntityFrameworkCore;
using SolucaoErp.Model;
using SolucaoErp.Repository.Config;

namespace SolucaoErp.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public static String dadosDeAcesso()
        {
            var servidor = "localhost";
            var usuario = "root";
            var senha = "123";
            var porta = "3306";
            var banco = "solucaoerp";
            var auxVsar = Environment.GetEnvironmentVariable("SERVIDOR");
            if (auxVsar != null && String.Empty.CompareTo(auxVsar) != 0)
            {
                servidor = auxVsar;
                usuario = Environment.GetEnvironmentVariable("USUARIO");
                senha = Environment.GetEnvironmentVariable("SENHA");
                porta = Environment.GetEnvironmentVariable("PORTA");
                banco = Environment.GetEnvironmentVariable("BANCO");
            }
            var resposta = $"server={servidor}; port={porta}; database={banco}; uid={usuario}; password={senha};Allow User Variables=False";
            return resposta;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(dadosDeAcesso(), ServerVersion.AutoDetect(dadosDeAcesso()));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbProdutoCgf());
            modelBuilder.ApplyConfiguration(new DbCategoriaCgf());
        }
    }
}

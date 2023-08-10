using Microsoft.EntityFrameworkCore;
using RegistroDePreco.Model;
using SolucaoErpDomain.Model;
using SolucaoErpDomain.Repository.Cfg;
using System.Data.Common;

namespace RegistroDePreco.Repository
{
    public class RegistroPrecoContext : DbContext
    {
        public DbSet<RegistroPreco> RegistroPrecos { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public RegistroPrecoContext(DbContextOptions options) : base(options)
        {
        }

        public List<T> ExecutaTypedSql<T>(String sql, Func<DbDataReader, T> extractFunction)
        {
            List<T> list = new List<T>();
            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                this.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        list.Add(extractFunction.Invoke(result));
                    }
                }
            }
            return list;
        }

        public T? ExecutaOneTypedSql<T>(String sql, Func<DbDataReader, T> extractFunction)
        {
            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.Text;
                this.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    result.Read();
                    return extractFunction.Invoke(result);
                }
            }
        }

        public static string dadosDeAcesso()
        {
            var servidor = "localhost";
            var usuario = "root";
            var senha = "123";
            var porta = "3306";
            var banco = "registropreco";
            var auxVsar = Environment.GetEnvironmentVariable("SERVIDOR");
            if (auxVsar != null && string.Empty.CompareTo(auxVsar) != 0)
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
            modelBuilder.ApplyConfiguration(new DbProdutoCfg());
            modelBuilder.ApplyConfiguration(new DbRegistroPrecoCfg());
        }
    }
}

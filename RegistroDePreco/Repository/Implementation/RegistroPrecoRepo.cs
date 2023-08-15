using RegistroDePreco.Model;
using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configurations;
using System.Data.Common;

namespace RegistroDePreco.Repository.Implementation
{
    public class RegistroPrecoRepo : ITransientDependecy<IRegistroPrecoRepo, RegistroPrecoRepo>, IRegistroPrecoRepo
    {
        private readonly RegistroPrecoContext _context;

        private readonly Func<DbDataReader, RegistroPreco> extractFunction = (v) => new RegistroPreco()
        {
            //barCode = v.GetInt64(v.GetOrdinal("barCode"))
            //TODO corrigir isso
        };

        private String GetBaseSql()
        {
            return "SELECT * FROM registropreco.RegistroPreco";
        }

        public RegistroPrecoRepo(RegistroPrecoContext context)
        {
            _context = context;
        }

        public void ListarPrecos()
        {
            this._context.ExecutaTypedSql<RegistroPreco>(GetBaseSql(), extractFunction);
        }

        public RegistroPreco Salvar(RegistroPreco registro)
        {
            this._context.ExecutaTypedSql<RegistroPreco>(GetBaseSql(), extractFunction);
            this._context.RegistroPrecos.Add(registro);
            this._context.SaveChanges();
            return registro;
        }
    }
}

using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Model;

namespace RegistroDePreco.Repository.Implementation
{
    public class ExtratoPontoRepo : IExtratoPontoRepo, ITransientDependecy<IExtratoPontoRepo, ExtratoPontoRepo>
    {
        private readonly RegistroPrecoContext _context;

        public ExtratoPontoRepo(RegistroPrecoContext context)
        {
            _context = context;
        }

        public void Salvar(ExtratoDePonto extratoPonto)
        {
            _context.ExtratoPonto.Add(extratoPonto);
            _context.SaveChanges();
        }
    }
}

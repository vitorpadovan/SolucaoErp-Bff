using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configuration.ErrorsApi;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Model;

namespace RegistroDePreco.Repository.Implementation
{
    public class PdvRepo : IPdvRepo, ITransientDependecy<IPdvRepo, PdvRepo>
    {
        public readonly RegistroPrecoContext _context;

        public PdvRepo(RegistroPrecoContext context)
        {
            _context = context;
        }

        public Pdv GetById(int id)
        {
            var resultado = _context.Pdv.Where(p => p.Id == id).FirstOrDefault();
            if (resultado == null)
                throw new NotFoundException($"Pdv com o id {id} não foi encontrado");
            return resultado;
        }

        public Pdv Salvar(Pdv pdv)
        {
            this._context.Pdv.Add(pdv);
            this._context.SaveChanges();
            return pdv;
        }
    }
}

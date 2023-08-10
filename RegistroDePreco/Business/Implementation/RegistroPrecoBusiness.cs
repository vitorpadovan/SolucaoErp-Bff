using RegistroDePreco.Business.Interfaces;
using RegistroDePreco.Model;
using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configurations;

namespace RegistroDePreco.Business.Implementation
{
    public class RegistroPrecoBusiness : ITransientDependecy<IRegistroPrecoBusiness, RegistroPrecoBusiness>, IRegistroPrecoBusiness
    {
        private readonly IRegistroPrecoRepo _repo;
        private readonly IProdutoRepo _produtoRepo;


        public RegistroPrecoBusiness(IRegistroPrecoRepo repo, IProdutoRepo produtoRepo)
        {
            _repo = repo;
            _produtoRepo = produtoRepo;
        }

        public void RegistrarPreco(RegistroPreco registro)
        {
            var produto = _produtoRepo.GetProduto(registro.barCode.ToString());
            _repo.Salvar(registro);
        }
    }
}

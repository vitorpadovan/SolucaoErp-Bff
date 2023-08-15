using RegistroDePreco.Business.Interfaces;
using RegistroDePreco.Model;
using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Auth.Context;
using SolucaoErpDomain.Configurations;

namespace RegistroDePreco.Business.Implementation
{
    public class RegistroPrecoBusiness : ITransientDependecy<IRegistroPrecoBusiness, RegistroPrecoBusiness>, IRegistroPrecoBusiness
    {
        private readonly IRegistroPrecoRepo _repo;
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IPdvBusiness _pdvBusiness;
        private readonly IAuthContext _authContext;
        private readonly IExtratoPontoRepo _extratoPontoRepo;

        public RegistroPrecoBusiness(IRegistroPrecoRepo repo, IProdutoBusiness produtoBusiness, IPdvBusiness pdvBusiness, IAuthContext authContext, IExtratoPontoRepo extratoPontoRepo)
        {
            _repo = repo;
            _produtoBusiness = produtoBusiness;
            _pdvBusiness = pdvBusiness;
            _authContext = authContext;
            _extratoPontoRepo = extratoPontoRepo;
        }

        public RegistroPreco RegistrarPreco(RegistroPreco registro)
        {
            Guid codEvento = Guid.NewGuid();
            registro.codRegistro = codEvento;
            var usuario = _authContext.GetUsuario();
            var produto = _produtoBusiness.GetProduto(registro.produto.CodigoBarras);
            registro.produto = produto;
            var pdv = _pdvBusiness.GetPdvById(registro.pdv.Id);
            registro.pdv = pdv;
            _repo.Salvar(registro);
            _extratoPontoRepo.Salvar(new()
            {
                Id = codEvento,
                Pontos = 1,
                DescricaoEvento = $"Registrando preço de {registro.produto.CodigoBarras}",
                Usuario = usuario,
                TipoExtrato = SolucaoErpDomain.Model.Enuns.TipoExtrato.CadastroPreco
            });
            return registro;
        }
    }
}

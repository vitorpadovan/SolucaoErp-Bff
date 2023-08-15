using RegistroDePreco.Business.Interfaces;
using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Auth.Context;
using SolucaoErpDomain.Configuration.ErrorsApi;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Model;

namespace RegistroDePreco.Business.Implementation
{
    public class PdvBusiness : IPdvBusiness, ITransientDependecy<IPdvBusiness, PdvBusiness>
    {
        private readonly IPdvRepo _pdvRepo;
        private readonly IAuthContext _authContext;
        private readonly IExtratoPontoRepo _extratoPontoRepo;

        public PdvBusiness(IPdvRepo pdvRepo, IAuthContext authContext, IExtratoPontoRepo extratoPontoRepo)
        {
            _pdvRepo = pdvRepo;
            _authContext = authContext;
            _extratoPontoRepo = extratoPontoRepo;
        }

        public Pdv GetPdvById(int id)
        {
            var retorno = _pdvRepo.GetById(id);
            if (retorno == null)
                throw new NotFoundException("Item não encontrado");
            return retorno;
        }

        public Pdv SalvarPdv(Pdv pdv)
        {
            var usuario = _authContext.GetUsuario();
            var codEvento = new Guid();
            _extratoPontoRepo.Salvar(new()
            {
                Id = codEvento,
                Pontos = 3,
                DescricaoEvento = $"Salvando PDV com o nome de {pdv.Nome}",
                Usuario = usuario,
                TipoExtrato = SolucaoErpDomain.Model.Enuns.TipoExtrato.CadastroPdv
            });
            return _pdvRepo.Salvar(pdv);
        }
    }
}

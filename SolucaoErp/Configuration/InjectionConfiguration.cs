using Microsoft.EntityFrameworkCore;
using SolucaoErp.Business.Imp;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Model;
using SolucaoErp.Repository;
using SolucaoErp.Repository.Imp;
using SolucaoErp.Repository.Interfaces;

namespace SolucaoErp.Configuration
{
    public class InjectionConfiguration
    {
        private IServiceCollection service;

        private InjectionConfiguration(IServiceCollection service)
        {
            this.service = service;
        }

        public static void AddInjectionDependency(IServiceCollection service)
        {
            var injectioDependency = new InjectionConfiguration(service);
            injectioDependency.AddRepository();
            injectioDependency.AddBusiness();
        }

        private void AddBusiness()
        {
            service.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            service.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
        }

        private void AddRepository()
        {
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucaoErpDomain.Model;

namespace SolucaoErpDomain.Repository.Cfg
{
    public class DbProdutoCfg : DbCfg<Produto>
    {
        protected override void Columns(EntityTypeBuilder<Produto> cfg)
        {

        }

        protected override void Fk(EntityTypeBuilder<Produto> cfg)
        {

        }

        protected override void Indices(EntityTypeBuilder<Produto> cfg)
        {
            cfg.HasIndex(p => p.CodigoBarras).IsUnique();
            cfg.HasIndex(p => p.Nome).IsUnique();
        }

        protected override void Keys(EntityTypeBuilder<Produto> cfg)
        {
            cfg.HasKey(p => p.Id);
        }
    }
}

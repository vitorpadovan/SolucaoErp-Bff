using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucaoErpDomain.Model;

namespace SolucaoErpDomain.Repository.Cfg
{
    public class DbExtratoDePontoCfg : DbCfg<ExtratoDePonto>
    {
        protected override void Columns(EntityTypeBuilder<ExtratoDePonto> cfg)
        {

        }

        protected override void Fk(EntityTypeBuilder<ExtratoDePonto> cfg)
        {

        }

        protected override void Indices(EntityTypeBuilder<ExtratoDePonto> cfg)
        {
            cfg.HasIndex(p => p.Usuario);
        }

        protected override void Keys(EntityTypeBuilder<ExtratoDePonto> cfg)
        {
            cfg.HasKey(p => p.Id);
            cfg.ToTable("ExtratoDePonto");
        }
    }
}

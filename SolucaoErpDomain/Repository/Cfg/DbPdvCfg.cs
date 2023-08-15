using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucaoErpDomain.Model;

namespace SolucaoErpDomain.Repository.Cfg
{
    public class DbPdvCfg : DbCfg<Pdv>
    {
        protected override void Columns(EntityTypeBuilder<Pdv> cfg)
        {

        }

        protected override void Fk(EntityTypeBuilder<Pdv> cfg)
        {

        }

        protected override void Indices(EntityTypeBuilder<Pdv> cfg)
        {
            cfg.HasIndex(p => p.Nome);
        }

        protected override void Keys(EntityTypeBuilder<Pdv> cfg)
        {
            cfg.HasKey(x => x.Id);
            cfg.ToTable("Pdv");
        }
    }
}

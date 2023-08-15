using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroDePreco.Model;

namespace SolucaoErpDomain.Repository.Cfg
{
    public class DbRegistroPrecoCfg : DbCfg<RegistroPreco>
    {
        protected override void Columns(EntityTypeBuilder<RegistroPreco> cfg)
        {
        }

        protected override void Fk(EntityTypeBuilder<RegistroPreco> cfg)
        {
        }

        protected override void Indices(EntityTypeBuilder<RegistroPreco> cfg)
        {

        }

        protected override void Keys(EntityTypeBuilder<RegistroPreco> cfg)
        {
            cfg.HasKey(p => p.codRegistro);
            cfg.ToTable("RegistroPreco");
        }
    }
}

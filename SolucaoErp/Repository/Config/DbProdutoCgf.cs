using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucaoErp.Model;

namespace SolucaoErp.Repository.Config;
public class DbProdutoCgf : DbCfg<Produto>
{
    protected override void Columns(EntityTypeBuilder<Produto> cfg)
    {
        //throw new NotImplementedException();
    }

    protected override void Fk(EntityTypeBuilder<Produto> cfg)
    {
        //throw new NotImplementedException();
    }

    protected override void Indices(EntityTypeBuilder<Produto> cfg)
    {
        cfg.HasIndex(p => p.Nome).IsUnique();
    }

    protected override void Keys(EntityTypeBuilder<Produto> cfg)
    {
        cfg.HasKey(p => p.Id);
    }
}
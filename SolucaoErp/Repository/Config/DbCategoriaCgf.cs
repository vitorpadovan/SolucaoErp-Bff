using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolucaoErp.Model;

namespace SolucaoErp.Repository.Config;
public class DbCategoriaCgf : DbCfg<Categoria>
{
    protected override void Columns(EntityTypeBuilder<Categoria> cfg)
    {
    }

    protected override void Fk(EntityTypeBuilder<Categoria> cfg)
    {
        //throw new NotImplementedException();
    }

    protected override void Indices(EntityTypeBuilder<Categoria> cfg)
    {
        cfg.HasIndex(p => p.Nome).IsUnique();
    }

    protected override void Keys(EntityTypeBuilder<Categoria> cfg)
    {
        cfg.HasKey(p => p.Id);
    }
}
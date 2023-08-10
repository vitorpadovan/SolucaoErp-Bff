using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolucaoErpDomain.Repository
{
    public abstract class DbCfg<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            Indices(builder);
            Keys(builder);
            Fk(builder);
            Columns(builder);
        }
        protected abstract void Indices(EntityTypeBuilder<T> cfg);
        protected abstract void Keys(EntityTypeBuilder<T> cfg);
        protected abstract void Fk(EntityTypeBuilder<T> cfg);
        protected abstract void Columns(EntityTypeBuilder<T> cfg);
    }
}

using SolucaoErpDomain.Model;

namespace RegistroDePreco.Repository.Interfaces
{
    public interface IProdutoRepo
    {
        public Produto GetProduto(int cod);
        public Produto? GetProduto(string barCode);

        public Produto SalvarProduto(Produto produto);
    }
}

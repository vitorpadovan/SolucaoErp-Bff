using SolucaoErpDomain.Model;

namespace RegistroDePreco.Business.Interfaces
{
    public interface IProdutoBusiness
    {
        Produto GetProduto(string v);
        public Produto SalvarProduto(Produto produto);
    }
}

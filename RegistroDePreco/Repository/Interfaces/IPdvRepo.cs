using SolucaoErpDomain.Model;

namespace RegistroDePreco.Repository.Interfaces
{
    public interface IPdvRepo
    {
        public Pdv GetById(int id);
        public Pdv Salvar(Pdv pdv);
    }
}

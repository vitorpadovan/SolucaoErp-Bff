using SolucaoErpDomain.Model;

namespace RegistroDePreco.Business.Interfaces
{
    public interface IPdvBusiness
    {
        public Pdv GetPdvById(int id);
        public Pdv SalvarPdv(Pdv pdv);
    }
}

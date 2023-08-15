using RegistroDePreco.Model;

namespace RegistroDePreco.Repository.Interfaces
{
    public interface IRegistroPrecoRepo
    {
        public RegistroPreco Salvar(RegistroPreco registro);

        public void ListarPrecos();
    }
}

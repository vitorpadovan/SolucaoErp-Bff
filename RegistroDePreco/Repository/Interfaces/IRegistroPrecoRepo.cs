using RegistroDePreco.Model;

namespace RegistroDePreco.Repository.Interfaces
{
    public interface IRegistroPrecoRepo
    {
        public void Salvar(RegistroPreco registro);

        public void ListarPrecos();
    }
}

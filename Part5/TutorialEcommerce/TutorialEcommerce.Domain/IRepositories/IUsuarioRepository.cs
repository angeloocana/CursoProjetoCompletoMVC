using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        bool CpfJaCadastrado(Cpf cpf, int usuarioId);
        bool LoginJaCadastrado(string login, int usuarioId);
        Usuario Get(string login);
        Usuario Get(Email email);
        Usuario Get(int id);
        void Salvar(Usuario usuario);
    }
}
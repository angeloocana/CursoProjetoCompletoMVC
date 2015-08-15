using System.Linq;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IRepositories;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioRepository(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool CpfJaCadastrado(Cpf cpf, int usuarioId)
        {
            return _usuarioRepository.Get().Any(x => x.Cpf.Codigo == cpf.Codigo
                                           && x.Id != usuarioId);
        }

        public bool LoginJaCadastrado(string login, int usuarioId)
        {
            return _usuarioRepository.Get().Any(x => x.Login == login
                                           && x.Id != usuarioId);
        }

        public void Salvar(Usuario usuario)
        {
            _usuarioRepository.AddOrUpdate(usuario);
            _usuarioRepository.Commit();
        }

        public Usuario Get(int id)
        {
            return _usuarioRepository.Get(id);
        }

        public Usuario Get(string login)
        {
            return _usuarioRepository.Get()
                .FirstOrDefault(x => x.Login == login);
        }
        
        public Usuario Get(Email email)
        {
            return _usuarioRepository.Get()
                .FirstOrDefault(x => x.Email.Endereco == email.Endereco);
        }
    }
}
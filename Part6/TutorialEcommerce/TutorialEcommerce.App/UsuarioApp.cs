using System;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IApp;
using TutorialEcommerce.Domain.IRepositories;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.App
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApp(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Get(string login)
        {
            return _usuarioRepository.Get(login);
        }

        public Usuario Get(Email email)
        {
            return _usuarioRepository.Get(email);
        }

        public Usuario Get(int id)
        {
            return _usuarioRepository.Get(id);
        }

        public void Salvar(Usuario usuario)
        {
            if(_usuarioRepository.CpfJaCadastrado(usuario.Cpf,usuario.Id))
                throw new Exception("CPF já cadastrado para outro usuário!");

            if (_usuarioRepository.LoginJaCadastrado(usuario.Login, usuario.Id))
                throw new Exception("Login já cadastrado para outro usuário!!");

            _usuarioRepository.Salvar(usuario);
        }
    }
}

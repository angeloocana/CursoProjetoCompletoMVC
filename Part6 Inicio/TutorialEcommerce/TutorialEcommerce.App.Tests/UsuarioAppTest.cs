using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.Enuns;
using TutorialEcommerce.Domain.IRepositories;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.App.Tests
{
    [TestClass]
    public class UsuarioAppTest
    {
        private readonly Usuario _usuario;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;

        public UsuarioAppTest()
        {
            var endereco = new Endereco("rua teste", "complemento teste", "numero teste", "bairro teste", "cidade teste", Uf.SP, new Cep("06400-000"));
            _usuario = new Usuario("loginTeste1", new Cpf("356.354.274-05"), new Email("emailTeste1@teste.com"), "senhaTeste",
                "senhaTeste", endereco);
            _usuarioRepository = new Mock<IUsuarioRepository>();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UsuarioApp_Salvar_CPF_JaCadastrado()
        {
            _usuarioRepository.Setup(x => x.CpfJaCadastrado(_usuario.Cpf, _usuario.Id)).Returns(true);
            var app = new UsuarioApp(_usuarioRepository.Object);
            app.Salvar(_usuario);
            _usuarioRepository.Verify(x => x.Salvar(_usuario), Times.Never);
        }

        [TestMethod]
        public void UsuarioApp_Salvar_CPF_Novo()
        {
            _usuarioRepository.Setup(x => x.CpfJaCadastrado(_usuario.Cpf, _usuario.Id)).Returns(false);
            var app = new UsuarioApp(_usuarioRepository.Object);
            app.Salvar(_usuario);
            _usuarioRepository.Verify(x => x.Salvar(_usuario), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UsuarioApp_Salvar_Login_JaCadastrado()
        {
            _usuarioRepository.Setup(x => x.LoginJaCadastrado(_usuario.Login, _usuario.Id)).Returns(true);
            var app = new UsuarioApp(_usuarioRepository.Object);
            app.Salvar(_usuario);
            _usuarioRepository.Verify(x => x.Salvar(_usuario), Times.Never);
        }

        [TestMethod]
        public void UsuarioApp_Salvar_Login_Novo()
        {
            _usuarioRepository.Setup(x => x.LoginJaCadastrado(_usuario.Login, _usuario.Id)).Returns(false);
            var app = new UsuarioApp(_usuarioRepository.Object);
            app.Salvar(_usuario);
            _usuarioRepository.Verify(x => x.Salvar(_usuario), Times.Once);
        }
    }
}

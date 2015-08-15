using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IRepositories;
using TutorialEcommerce.Domain.ValueObject;
using TutorialEcommerce.Repositories.Tests.TestData;

namespace TutorialEcommerce.Repositories.Tests
{
    [TestClass]
    public class UsuarioRepositoryTests
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly RepositoryList<Usuario> _repository;

        public UsuarioRepositoryTests()
        {
            _repository = new RepositoryList<Usuario>(UsuarioTestData.Get());
            _usuarioRepository = new UsuarioRepository(_repository);
        }

        [TestMethod]
        public void UsuarioRepository_CpfJaCadastrado_Ja_Cadastrado_Novo_Usuario()
        {
            var jaCadastrado = _usuarioRepository.CpfJaCadastrado(new Cpf("356.354.274-05"), 0);
            Assert.IsTrue(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_CpfJaCadastrado_Ja_Cadastrado_Proprio_Usuario()
        {
            var jaCadastrado = _usuarioRepository.CpfJaCadastrado(new Cpf("356.354.274-05"), 1);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_CpfJaCadastrado_Nao_Cadastrado()
        {
            var jaCadastrado = _usuarioRepository.CpfJaCadastrado(new Cpf("001.832.936-57"), 0);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_LoginJaCadastrado_Ja_Cadastrado_Novo_Usuario()
        {
            var jaCadastrado = _usuarioRepository.LoginJaCadastrado("loginTeste1", 0);
            Assert.IsTrue(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_LoginJaCadastrado_Ja_Cadastrado_Proprio_Usuario()
        {
            var jaCadastrado = _usuarioRepository.LoginJaCadastrado("loginTeste1", 1);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_LoginJaCadastrado_Nao_Cadastrado()
        {
            var jaCadastrado = _usuarioRepository.LoginJaCadastrado("afsdhbdfbhdfsb", 0);
            Assert.IsFalse(jaCadastrado);
        }

        [TestMethod]
        public void UsuarioRepository_Salvar_Novo()
        {
            var usuario = new Usuario("loginTesteSalvar", new Cpf("018.971.571-50"), new Email("emailTesteSalvar@teste.com"),
                "senhaTeste", "senhaTeste", UsuarioTestData.GetEnderecoTest());

            var totalAntesDeSalvar = _repository.Get().Count();
            _usuarioRepository.Salvar(usuario);
            var totalDepoisDeSalvar = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalAntesDeSalvar + 1, totalDepoisDeSalvar);
        }

        [TestMethod]
        public void UsuarioRepository_Salvar_JaCadastrado()
        {
            var usuario = _repository.First();
            var novoEmail = new Email("novoEmail@email.com");
            usuario.SetEmail(novoEmail);

            var totalAntesDeSalvar = _repository.Get().Count();
            _usuarioRepository.Salvar(usuario);
            var totalDepoisDeSalvar = _repository.Get().Count();

            Assert.IsTrue(_repository.Commited);
            Assert.AreEqual(totalAntesDeSalvar, totalDepoisDeSalvar);
            Assert.AreEqual(usuario.Email, _repository.First().Email);
        }

        [TestMethod]
        public void UsuarioRepository_Get_Id()
        {
            var usuario = _repository.First();
            Assert.AreEqual(usuario, _usuarioRepository.Get(usuario.Id));
        }

        [TestMethod]
        public void UsuarioRepository_Get_Login()
        {
            var usuario = _repository.First();
            Assert.AreEqual(usuario, _usuarioRepository.Get(usuario.Login));
        }

        [TestMethod]
        public void UsuarioRepository_Get_Email()
        {
            var usuario = _repository.First();
            Assert.AreEqual(usuario, _usuarioRepository.Get(usuario.Email));
        }
    }
}

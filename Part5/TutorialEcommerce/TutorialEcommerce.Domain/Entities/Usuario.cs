using System;
using System.Linq;
using TutorialEcommerce.Domain.ValueObject;
using TutorialEcommerce.Helpers;

namespace TutorialEcommerce.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }

        public const int LoginMinLength = 6;
        public const int LoginMaxLength = 30;
        public string Login { get; private set; }

        public Endereco Endereco { get; private set; }

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;
        public byte[] Senha { get; private set; }

        public Guid TokenAlteracaoDeSenha { get; private set; }

        //Construtor EntityFramework
        protected Usuario()
        {

        }

        public Usuario(string login, Cpf cpf, Email email, string senha, string senhaConfirmacao, Endereco endereco)
        {
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senha, senhaConfirmacao);
            Endereco = endereco;
            DtInclusao = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, LoginMinLength, LoginMaxLength);
            Login = login;
        }

        public void SetCpf(Cpf cpf)
        {
            if (cpf == null)
                throw new Exception("Cpf Obrigatório");
            Cpf = cpf;
        }

        public void SetEmail(Email email)
        {
            if (email == null)
                throw new Exception("E-mail Obrigatório");
            Email = email;
        }

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength("Senha", senha, SenhaMinLength, SenhaMaxLength);
            Guard.AreEqual(senha, senhaConfirmacao, "As senhas não conferem!");
            
            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoDeSenha)
        {
            ValidarSenha(senhaAtual);
            SetSenha(novaSenha, confirmacaoDeSenha);
        }

        public void ValidarSenha(string senha)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            var senhaCriptografada = CriptografiaHelper.CriptografarSenha(senha);
            if (!Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha inválida!");
        }

        public Guid GerarNovoTokenAlterarSenha()
        {
            TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoDeSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("token para alteração de senha inválido!");
            SetSenha(novaSenha, confirmacaoDeSenha);
            GerarNovoTokenAlterarSenha();
        }
    }
}

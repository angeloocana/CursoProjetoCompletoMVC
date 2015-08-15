using System.Collections.Generic;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.Enuns;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Repositories.Tests.TestData
{
    public class UsuarioTestData
    {
        public static Endereco GetEnderecoTest()
        {
            return new Endereco("rua teste", "complemento teste", "numero teste", "bairro teste", "cidade teste", Uf.SP, new Cep("06400-000"));
        }

        public static List<Usuario> Get()
        {
            return new List<Usuario>
            {
               new Usuario("loginTeste1",new Cpf("356.354.274-05"),new Email("emailTeste1@teste.com"),"senhaTeste","senhaTeste", GetEnderecoTest()){Id=1} ,
               new Usuario("loginTeste2",new Cpf("763.257.104-36"),new Email("emailTeste2@teste.com"),"senhaTeste","senhaTeste", GetEnderecoTest()){Id=2} ,
               new Usuario("loginTeste3",new Cpf("727.289.152-10"),new Email("emailTeste3@teste.com"),"senhaTeste","senhaTeste", GetEnderecoTest()) {Id=3},
               new Usuario("loginTeste4",new Cpf("846.764.546-60"),new Email("emailTeste4@teste.com"),"senhaTeste","senhaTeste", GetEnderecoTest()){Id=4} ,
               new Usuario("loginTeste5",new Cpf("182.415.465-80"),new Email("emailTeste5@teste.com"),"senhaTeste","senhaTeste", GetEnderecoTest()) {Id=5}
            };
        }
    }
}

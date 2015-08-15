using System.Data.Entity.Migrations;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.Enuns;
using TutorialEcommerce.Domain.ValueObject;

namespace TutorialEcommerce.Repositories.Seeds
{
    public class UsuarioSeed
    {
        public static void Seed(EfDbContext context)
        {
            var endereco = new Endereco("Rua teste", "complemento teste", "numero teste", "bairroteste", "cidadeteste",
                Uf.SP, new Cep("06414-110"));

            context.Usuarios.AddOrUpdate(x => x.Login,
                new Usuario("adminMaster", new Cpf("40914294830"), new Email("angeloocana@gmail.com"), "testeteste", "testeteste", endereco));
        }
    }
}

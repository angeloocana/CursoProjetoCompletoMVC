using TutorialEcommerce.Repositories.Seeds;

namespace TutorialEcommerce.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TutorialEcommerce.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TutorialEcommerce.Repositories.EfDbContext context)
        {
            UsuarioSeed.Seed(context);
        }
    }
}

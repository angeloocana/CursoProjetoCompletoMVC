namespace TutorialEcommerce.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations_Banco_Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.Long(nullable: false),
                        Email = c.String(maxLength: 254, unicode: false),
                        Login = c.String(maxLength: 30, unicode: false),
                        Logradouro = c.String(maxLength: 150, unicode: false),
                        Complemento = c.String(maxLength: 150, unicode: false),
                        Numero = c.String(maxLength: 50, unicode: false),
                        Bairro = c.String(maxLength: 150, unicode: false),
                        Cidade = c.String(maxLength: 150, unicode: false),
                        Uf = c.Int(),
                        Cep = c.Long(),
                        Senha = c.Binary(),
                        TokenAlteracaoDeSenha = c.Guid(nullable: false),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cpf, unique: true, name: "IX_CPF")
                .Index(t => t.Email, unique: true)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", new[] { "Login" });
            DropIndex("dbo.Usuario", new[] { "Email" });
            DropIndex("dbo.Usuario", "IX_CPF");
            DropTable("dbo.Usuario");
        }
    }
}

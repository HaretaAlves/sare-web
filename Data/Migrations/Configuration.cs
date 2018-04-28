namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.SareWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.SareWebContext context)
        {
            context.Usuarios.AddOrUpdate(o => o.ID, new Domain.Models.UsuarioModel
            {
                ID = 1,
                Login = "admin",
                Nome = "Administrador",
                Senha = "123456",
                Email = "hareta.alves@gmail.com",
                Status = "SINC",
                LastModifiedDate = DateTime.Now
            });
            
        }
    }
}

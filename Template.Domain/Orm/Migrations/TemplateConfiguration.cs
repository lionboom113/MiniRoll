namespace Template.Domain.Orm.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity;
    using Orm;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class TemplateConfiguration : DbMigrationsConfiguration<TemplateDbContext>
    {
        public TemplateConfiguration()
        {
            //�^�p����false�ɂ��邱��
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TemplateDbContext context)
        {
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new User
                {
                    UserName = "sakamoto-y",
                    Password = new PasswordHasher().HashPassword("p@ssw0rd"),
                    Roles = new[] { new Role { Controller = "Home", Action = "Index", IsWritable = true } },
                });
                context.SaveChanges();
            }
        }
    }
}

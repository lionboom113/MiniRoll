using System.Data.Entity;
using Template.Domain.Entities;
using Template.Domain.Orm.Migrations;

namespace Template.Domain.Orm
{
    /// <summary>
    /// <para>データを管理するDatabaseへのアクセスを提供するDbContext.</para>
    /// <para>ConnectionStringはWeb.config内に定義する.</para>
    /// <para>インスタンスは要求単位で保持する.</para>
    /// </summary>
    public class TemplateDbContext : DbContext
    {
#if DEBUG
        static TemplateDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateDbContext, TemplateConfiguration>());
        }
#endif

        public TemplateDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
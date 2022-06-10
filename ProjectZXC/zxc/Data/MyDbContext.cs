using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxc.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);

        }

        public DbSet<Tables.deal> deals { get; set; }
        public DbSet<Tables.good> goods { get; set; }
        public DbSet<Tables.macler> maclers { get; set; }
        public DbSet<Tables.maclerStatistic> maclerStatistics { get; set; }
    }
}

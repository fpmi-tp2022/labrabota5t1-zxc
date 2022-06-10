using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxc.Data;

namespace zxc.Migrations
{
    internal sealed class Configuretion:DbMigrationsConfiguration<Data.MyDbContext>
    {
        public Configuretion() {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);
        }
    }
}

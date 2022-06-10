using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxc.Data
{
    public class MyDbContextInitializer : SqliteDropCreateDatabaseAlways<MyDbContext>
    {
        public MyDbContextInitializer(DbModelBuilder modelBuilder) : base(modelBuilder) { }

        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);
        }
    }
}

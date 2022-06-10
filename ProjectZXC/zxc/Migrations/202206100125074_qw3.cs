namespace zxc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qw3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.maclerStatisticd",
                c => new
                    {
                        statisticsId = c.Long(nullable: false, identity: true),
                        maclerID = c.Int(nullable: false),
                        maclerName = c.String(maxLength: 2147483647),
                        amount = c.Int(nullable: false),
                        sumprice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.statisticsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.maclerStatisticd");
        }
    }
}

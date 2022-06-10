namespace zxc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.deals",
                c => new
                    {
                        dealId = c.Long(nullable: false, identity: true),
                        date = c.String(nullable: false, maxLength: 2147483647),
                        name = c.String(maxLength: 2147483647),
                        type = c.String(maxLength: 2147483647),
                        amount = c.Int(nullable: false),
                        macler = c.String(maxLength: 2147483647),
                        customer = c.String(maxLength: 2147483647),
                        maclerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dealId);
            
            CreateTable(
                "dbo.goods",
                c => new
                    {
                        goodId = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 2147483647),
                        type = c.String(maxLength: 2147483647),
                        price = c.Double(nullable: false),
                        supplier = c.String(maxLength: 2147483647),
                        storeDate = c.String(maxLength: 2147483647),
                        amount = c.Int(nullable: false),
                        maclerId = c.Int(nullable: false),
                        dealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.goodId);
            
            CreateTable(
                "dbo.maclers",
                c => new
                    {
                        maclerId = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 2147483647),
                        address = c.String(maxLength: 2147483647),
                        birthday = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.maclerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.maclers");
            DropTable("dbo.goods");
            DropTable("dbo.deals");
        }
    }
}

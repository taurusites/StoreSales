namespace StorePayments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTables",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddLine1 = c.String(nullable: false, maxLength: 50),
                        AddLine2 = c.String(maxLength: 50),
                        StateId = c.Int(nullable: false),
                        Zip = c.String(nullable: false, maxLength: 5),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.StateNames",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false, maxLength: 50),
                        AddressTable_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.AddressTables", t => t.AddressTable_AddressId)
                .Index(t => t.AddressTable_AddressId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        EmailId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressTables", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.StateNames", "AddressTable_AddressId", "dbo.AddressTables");
            DropIndex("dbo.StateNames", new[] { "AddressTable_AddressId" });
            DropIndex("dbo.AddressTables", new[] { "VendorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stores");
            DropTable("dbo.Vendors");
            DropTable("dbo.StateNames");
            DropTable("dbo.AddressTables");
        }
    }
}

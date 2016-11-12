namespace HummusInWonderland.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        BranchCity = c.String(nullable: false),
                        BranchStreet = c.String(nullable: false),
                        BranchsHouseNumber = c.Int(nullable: false),
                        BranchsPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        City = c.String(),
                        Street = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        menu_MenuID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Menu", t => t.menu_MenuID)
                .Index(t => t.CustomerId)
                .Index(t => t.menu_MenuID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductImage = c.String(),
                    })
                .PrimaryKey(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "menu_MenuID", "dbo.Menu");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "menu_MenuID" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropTable("dbo.Menu");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.Branch");
        }
    }
}

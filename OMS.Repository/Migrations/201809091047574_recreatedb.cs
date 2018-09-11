namespace OMS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 30),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        ParentCategory_ID = c.Int(),
                        Variant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_ID)
                .ForeignKey("dbo.Variants", t => t.Variant_ID)
                .Index(t => t.ParentCategory_ID)
                .Index(t => t.Variant_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 25),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Variant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Variants", t => t.Variant_ID)
                .Index(t => t.CategoryId)
                .Index(t => t.Variant_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Product_ID = c.Int(nullable: false),
                        Transaction_ID = c.Int(),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .ForeignKey("dbo.Transactions", t => t.Transaction_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Transaction_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Address_ID = c.Int(),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressLineOne = c.String(nullable: false, maxLength: 25),
                        AddressLineTwo = c.String(maxLength: 25),
                        City = c.String(nullable: false, maxLength: 25),
                        PostalCode = c.String(maxLength: 10),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        MobileNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 25),
                        Gender = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Address_ID = c.Int(),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 25),
                        PasswordHash = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Salt = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        MobileNumber = c.Int(nullable: false),
                        Tin = c.Int(nullable: false),
                        BusinessName = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Transactions", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.InventoryLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                        InvoiceNumber = c.Int(nullable: false),
                        Process = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Product_ID = c.Int(nullable: false),
                        Supplier_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GoodQuantity = c.Int(nullable: false),
                        DamagedQuantity = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        product_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.product_ID)
                .Index(t => t.product_ID);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Variant_ID", "dbo.Variants");
            DropForeignKey("dbo.Categories", "Variant_ID", "dbo.Variants");
            DropForeignKey("dbo.Stocks", "product_ID", "dbo.Products");
            DropForeignKey("dbo.InventoryLogs", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.InventoryLogs", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Orders", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Orders", "Transaction_ID", "dbo.Transactions");
            DropForeignKey("dbo.Customers", "ID", "dbo.Transactions");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Users", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Accounts", "ID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_ID", "dbo.Categories");
            DropIndex("dbo.Stocks", new[] { "product_ID" });
            DropIndex("dbo.InventoryLogs", new[] { "Supplier_ID" });
            DropIndex("dbo.InventoryLogs", new[] { "Product_ID" });
            DropIndex("dbo.Customers", new[] { "ID" });
            DropIndex("dbo.Accounts", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Users", new[] { "Address_ID" });
            DropIndex("dbo.Transactions", new[] { "User_ID" });
            DropIndex("dbo.Transactions", new[] { "Address_ID" });
            DropIndex("dbo.Orders", new[] { "User_ID" });
            DropIndex("dbo.Orders", new[] { "Transaction_ID" });
            DropIndex("dbo.Orders", new[] { "Product_ID" });
            DropIndex("dbo.Products", new[] { "Variant_ID" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Variant_ID" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_ID" });
            DropTable("dbo.Variants");
            DropTable("dbo.Stocks");
            DropTable("dbo.Suppliers");
            DropTable("dbo.InventoryLogs");
            DropTable("dbo.Customers");
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
            DropTable("dbo.Transactions");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

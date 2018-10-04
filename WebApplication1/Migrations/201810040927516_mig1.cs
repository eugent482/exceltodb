namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Color = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyName = c.String(),
                        OwnerName = c.String(),
                        OwnerSurname = c.String(),
                        Country = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblProducts");
        }
    }
}

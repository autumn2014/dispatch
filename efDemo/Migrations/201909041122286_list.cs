namespace efDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class list : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.Mice",
                c => new
                    {
                        MouseId = c.Int(nullable: false, identity: true),
                        MouseType = c.String(maxLength: 100, storeType: "nvarchar"),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MouseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mice");
        }
    }
}

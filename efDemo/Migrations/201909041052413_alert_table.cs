namespace efDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alert_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Keyboards", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Keyboards", "Name", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Keyboards", "Name", c => c.String(unicode: false));
            DropColumn("dbo.Keyboards", "Price");
        }
    }
}

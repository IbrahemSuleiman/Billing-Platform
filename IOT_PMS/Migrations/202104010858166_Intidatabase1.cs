namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intidatabase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DOB");
            DropColumn("dbo.AspNetUsers", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
        }
    }
}

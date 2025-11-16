namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Data4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.E_Bill");
            AlterColumn("dbo.E_Bill", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.E_Bill", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.E_Bill");
            AlterColumn("dbo.E_Bill", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.E_Bill", "Id");
        }
    }
}

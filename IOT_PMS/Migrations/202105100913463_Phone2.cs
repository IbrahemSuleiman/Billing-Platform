namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phone2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.P_Bill");
            DropPrimaryKey("dbo.P_Counter");
            AlterColumn("dbo.P_Bill", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.P_Counter", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.P_Bill", "Id");
            AddPrimaryKey("dbo.P_Counter", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.P_Counter");
            DropPrimaryKey("dbo.P_Bill");
            AlterColumn("dbo.P_Counter", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.P_Bill", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.P_Counter", "Id");
            AddPrimaryKey("dbo.P_Bill", "Id");
        }
    }
}

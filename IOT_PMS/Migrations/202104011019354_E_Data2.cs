namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Data2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter");
            DropIndex("dbo.E_Bill", new[] { "e_counter_Id" });
            DropPrimaryKey("dbo.E_Counter");
            AlterColumn("dbo.E_Bill", "e_counter_Id", c => c.Int());
            AlterColumn("dbo.E_Counter", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.E_Counter", "Id");
            CreateIndex("dbo.E_Bill", "e_counter_Id");
            AddForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter");
            DropIndex("dbo.E_Bill", new[] { "e_counter_Id" });
            DropPrimaryKey("dbo.E_Counter");
            AlterColumn("dbo.E_Counter", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.E_Bill", "e_counter_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.E_Counter", "Id");
            CreateIndex("dbo.E_Bill", "e_counter_Id");
            AddForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter", "Id");
        }
    }
}

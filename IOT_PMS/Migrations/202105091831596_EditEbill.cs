namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEbill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter");
            DropIndex("dbo.E_Bill", new[] { "e_counter_Id" });
            DropColumn("dbo.E_Bill", "user_FirstName");
            DropColumn("dbo.E_Bill", "user_LastName");
            DropColumn("dbo.E_Bill", "user_MiddleName");
            DropColumn("dbo.E_Bill", "user_Address");
            DropColumn("dbo.E_Bill", "user_Mobile");
            DropColumn("dbo.E_Bill", "user_NationalId");
            DropColumn("dbo.E_Bill", "e_counter_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.E_Bill", "e_counter_Id", c => c.Int());
            AddColumn("dbo.E_Bill", "user_NationalId", c => c.String());
            AddColumn("dbo.E_Bill", "user_Mobile", c => c.String());
            AddColumn("dbo.E_Bill", "user_Address", c => c.String());
            AddColumn("dbo.E_Bill", "user_MiddleName", c => c.String());
            AddColumn("dbo.E_Bill", "user_LastName", c => c.String());
            AddColumn("dbo.E_Bill", "user_FirstName", c => c.String());
            CreateIndex("dbo.E_Bill", "e_counter_Id");
            AddForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter", "Id");
        }
    }
}

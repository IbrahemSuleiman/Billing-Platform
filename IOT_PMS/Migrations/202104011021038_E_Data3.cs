namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Data3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.E_Counter", "user_FirstName");
            DropColumn("dbo.E_Counter", "user_LastName");
            DropColumn("dbo.E_Counter", "user_MiddleName");
            DropColumn("dbo.E_Counter", "user_Address");
            DropColumn("dbo.E_Counter", "user_Mobile");
            DropColumn("dbo.E_Counter", "user_NationalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.E_Counter", "user_NationalId", c => c.String());
            AddColumn("dbo.E_Counter", "user_Mobile", c => c.String());
            AddColumn("dbo.E_Counter", "user_Address", c => c.String());
            AddColumn("dbo.E_Counter", "user_MiddleName", c => c.String());
            AddColumn("dbo.E_Counter", "user_LastName", c => c.String());
            AddColumn("dbo.E_Counter", "user_FirstName", c => c.String());
        }
    }
}

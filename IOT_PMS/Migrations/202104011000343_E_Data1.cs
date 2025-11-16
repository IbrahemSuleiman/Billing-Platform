namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Data1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.E_Counter", "RegistrationType", c => c.String());
            DropColumn("dbo.E_Counter", "CounterType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.E_Counter", "CounterType", c => c.String());
            DropColumn("dbo.E_Counter", "RegistrationType");
        }
    }
}

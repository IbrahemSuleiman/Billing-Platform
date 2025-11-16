namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class E_Data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.E_Bill",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Number = c.String(),
                        DateofAnnounce = c.String(),
                        Price = c.String(),
                        Notes = c.String(),
                        UserId = c.String(),
                        user_FirstName = c.String(),
                        user_LastName = c.String(),
                        user_MiddleName = c.String(),
                        user_Address = c.String(),
                        user_Mobile = c.String(),
                        user_NationalId = c.String(),
                        CounterId = c.String(),
                        e_counter_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.E_Counter", t => t.e_counter_Id)
                .Index(t => t.e_counter_Id);
            
            CreateTable(
                "dbo.E_Counter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SerialNumber = c.String(),
                        CounterType = c.String(),
                        CounterValue = c.String(),
                        RegistrationDate = c.String(),
                        UserId = c.String(),
                        user_FirstName = c.String(),
                        user_LastName = c.String(),
                        user_MiddleName = c.String(),
                        user_Address = c.String(),
                        user_Mobile = c.String(),
                        user_NationalId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.E_Bill", "e_counter_Id", "dbo.E_Counter");
            DropIndex("dbo.E_Bill", new[] { "e_counter_Id" });
            DropTable("dbo.E_Counter");
            DropTable("dbo.E_Bill");
        }
    }
}

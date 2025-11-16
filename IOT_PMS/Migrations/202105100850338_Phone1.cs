namespace IOT_PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phone1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.P_Bill",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Number = c.String(),
                        DateofAnnounce = c.String(),
                        Price = c.String(),
                        Notes = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.P_Counter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(),
                        Duration = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.P_Counter");
            DropTable("dbo.P_Bill");
        }
    }
}

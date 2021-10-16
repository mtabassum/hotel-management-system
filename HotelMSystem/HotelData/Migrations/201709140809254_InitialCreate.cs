namespace HotelData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        mobile = c.String(nullable: false),
                        address = c.String(nullable: false),
                        hotelname = c.String(nullable: false),
                        totalrooms = c.Int(nullable: false),
                        totaldays = c.Int(nullable: false),
                        dueamount = c.Single(nullable: false),
                        bookingdate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Hotelinfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        hotelName = c.String(nullable: false),
                        rating = c.Int(nullable: false),
                        facilities = c.String(nullable: false),
                        roomprice = c.Single(nullable: false),
                        totalrooms = c.Int(nullable: false),
                        status = c.String(nullable: false),
                        address = c.String(nullable: false),
                        area = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
            DropTable("dbo.Hotelinfoes");
            DropTable("dbo.Bookings");
        }
    }
}

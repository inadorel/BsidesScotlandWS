namespace BsidesScotlandWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        address1 = c.String(nullable: false),
                        address2 = c.String(),
                        town = c.String(),
                        postcode = c.String(),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        SpeakerId = c.Int(nullable: false, identity: true),
                        speakerFirstName = c.String(nullable: false),
                        speakerLastName = c.String(),
                        speakerTitle = c.String(),
                        speakerEmail = c.String(),
                        speakerMobile = c.String(),
                        dinnerAttendee = c.Boolean(nullable: false),
                        vegetarian = c.Boolean(nullable: false),
                        tshirtSize = c.String(),
                        underEighteen = c.Boolean(nullable: false),
                        emergencyContactName = c.String(),
                        emergencyContactNumber = c.String(),
                        gender = c.String(),
                        talkTitle = c.String(),
                        international = c.Boolean(nullable: false),
                        dateSubmitted = c.DateTime(nullable: false),
                        expReq = c.Boolean(nullable: false),
                        track = c.String(),
                        talkAccepted = c.Boolean(nullable: false),
                        confirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpeakerId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        SponsorId = c.Int(nullable: false, identity: true),
                        sponsorFirstName = c.String(nullable: false),
                        sponsorLastName = c.String(),
                        sponsorTitle = c.String(),
                        sponsorEmail = c.String(),
                        sponsorMobile = c.String(),
                        sponsorCompanyName = c.String(),
                        sponsorLevel = c.String(),
                        sponsorStatus = c.String(),
                        contacted = c.Boolean(nullable: false),
                        responded = c.Boolean(nullable: false),
                        result = c.String(),
                        contactedBy = c.String(),
                        dinnerAttendee = c.Boolean(nullable: false),
                        vegetarian = c.Boolean(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SponsorId);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        VolunteerId = c.Int(nullable: false, identity: true),
                        volunteerFirstName = c.String(nullable: false),
                        volunteerLastName = c.String(),
                        volunteerTitle = c.String(),
                        volunteerEmail = c.String(),
                        volunteerMobile = c.String(),
                    })
                .PrimaryKey(t => t.VolunteerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Volunteers");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Speakers");
            DropTable("dbo.Addresses");
        }
    }
}

namespace BsidesScotlandWS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BsidesScotlandWS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BsidesScotlandWS.Models.BsidesScotlandWSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BsidesScotlandWS.Models.BsidesScotlandWSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Speakers.AddOrUpdate(x => x.SpeakerId,
        new Speaker() { SpeakerId = 1, speakerFirstName = "Rory", speakerLastName = "McCune" },
        new Speaker() { SpeakerId = 2, speakerFirstName = "Roderick", speakerLastName = "Jacks" },
        new Speaker() { SpeakerId = 3, speakerFirstName = "Neil", speakerLastName = "Ellis" }
        );

            context.Sponsors.AddOrUpdate(x => x.SponsorId,
                     new Sponsor() { SponsorId = 1, sponsorFirstName = "Martin", sponsorLastName = "Finch" },
                    new Sponsor() { SponsorId = 2, sponsorFirstName = "Paul", sponsorLastName = "Richie" },
                    new Sponsor() { SponsorId = 3, sponsorFirstName = "Mark", sponsorLastName = "Turner" }
                    );

            context.Volunteers.AddOrUpdate(x => x.VolunteerId,
                     new Volunteer() { VolunteerId = 1, volunteerFirstName = "Peter", volunteerLastName = "Innes" },
                    new Volunteer() { VolunteerId = 2, volunteerFirstName = "Angeline", volunteerLastName = "Lorial" },
                    new Volunteer() { VolunteerId = 3, volunteerFirstName = "Ponsonby", volunteerLastName = "Pinemarten" }
                    );
        }
    }
}

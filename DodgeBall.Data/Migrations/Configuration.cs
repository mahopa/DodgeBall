namespace DodgeBall.Data.Migrations
{
    using DodgeBall.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DodgeBall.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DodgeBall.Data.ApplicationDbContext context)
        {

            context.Teams.AddOrUpdate(x => x.Name,
                new Team() { Name = "Vipers", Logo = "http://SomelogoURL" },
                new Team() { Name = "Average Joes", Logo = "Later" }
                );
            context.SaveChanges();
            context.Players.AddOrUpdate(p => new { p.Name, p.TeamId },
                new Player() { Name = "Vince", TeamId = 2, Picture = "Tall and Gangly" },
                new Player() { Name = "Zoolander", TeamId = 1, Picture = "Really Really Good Looking" },
                new Player() { Name = "Vince2", TeamId = 2, Picture = "Tall and Gangly" },
                new Player() { Name = "Zoolander2", TeamId = 1, Picture = "Really Really Good Looking" }
                );
            context.SaveChanges();
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
        }
    }
}

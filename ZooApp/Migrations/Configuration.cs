namespace ZooApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZooApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZooApp.Models.ApplicationDbContext context)
        {
            var animals = new Animal[]{
                new Animal{Name = "Bob", Species = "BobCat", Quantity = 1},
                new Animal{Name = "Joshua", Species = "Were-Wolf", Quantity = 1},
                new Animal{Name = "George", Species = "Giraffe", Quantity = 1}
            };
            context.Animals.AddOrUpdate(m => m.Name, animals);
        }
    }
}

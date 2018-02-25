namespace TransportManager.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TransportManager.DataAccess.Models;
    using TransportManager.DataAccess.Enums;


    internal sealed class Configuration : DbMigrationsConfiguration<TransportManager.DataAccess.TransportManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TransportManager.DataAccess.TransportManagerContext context)
        {
            List<User> users = new List<User>
            {
                new User {FirstName = "111", LastName = "222", MiddleName = "333", Password = "qwerty", Email = "qqq", Gender = Gender.Female, LastVisit = DateTime.Now, Login = "zzz", Phone = "5555"}
            };
            users.ForEach(u => context.Users.AddOrUpdate(u));
        }
    }
}

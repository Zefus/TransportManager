using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using TransportManager.DataAccess.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.Composition;

namespace TransportManager.DataAccess
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class TransportManagerContext : DbContext
    {
        public TransportManagerContext() : base("TransportManagerConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transact> Transactions { get; set; }
        public DbSet<Bus> Buses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

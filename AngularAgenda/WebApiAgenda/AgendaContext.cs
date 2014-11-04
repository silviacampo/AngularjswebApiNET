using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiAgenda.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiAgenda
{
    class AgendaContext : DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<aevent> aevents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
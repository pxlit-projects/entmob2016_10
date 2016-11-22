using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrongPlateEF.Model;

namespace StrongPlateEF.DataLayer
{
    class StrongPlateContext : DbContext
    {
        public StrongPlateContext() : base("StrongPlateDB") { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Set primary key
            modelBuilder.Entity<Employee>().HasKey(e => e.ID);

            // Set property to be required
            modelBuilder.Entity<Employee>().Property(e => e.LastName).IsRequired();

            // Set the name of the column 
            modelBuilder.Entity<Employee>().Property(e => e.Male).HasColumnName("Gender");

            // Set the max length of a property
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}

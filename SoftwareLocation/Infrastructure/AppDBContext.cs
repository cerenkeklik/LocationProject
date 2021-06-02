
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class AppDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=tcp:location-software.database.windows.net,1433;Database=LocationDb;User ID=location;Password=Abcd1234;Trusted_Connection=False;Encrypt=True; ");



        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Manager> Managers { get; set; }

    }
}

﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular7CRUDDemo.Backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { ID=1, Fname = "Mangesh", Lname = "G", email = "Mangesh.g@outlook.com", gender = "1" },
                new Employee() { ID=2, Fname = "Ramnath", Lname = "Bodke", email = "Ramnagh.g@outlook.com", gender = "1" },
                new Employee() { ID=3, Fname = "Suraj", Lname = "G", email = "suraj.g@gmail.com", gender = "1" },
                new Employee() { ID = 4, Fname = "Jaffar", Lname = "K", email = "Jaffar.g@outlook.com", gender = "1" }
                );
        }
    }
}

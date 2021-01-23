using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RevAppoint.Domain.POCOs;

namespace RevAppoint.Storage
{
    public class RevAppointContext : DbContext
    {
        public DbSet<Appointment> Appointments {get;set;}
        public DbSet<Professional> Professionals {get;set;}
        public DbSet<Time> Times {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Customer> Users {get;set;}

        public RevAppointContext(DbContextOptions<RevAppointContext> options) : base(options){}
        public RevAppointContext(){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professional>().HasBaseType<User>().ToTable("Professional");
            builder.Entity<Customer>().HasBaseType<User>().ToTable("Customer");
            builder.Entity<Appointment>().HasKey(s => s.EntityID);
            builder.Entity<User>().HasKey(s => s.EntityID);
            builder.Entity<Time>().HasKey(s => s.EntityID);

            builder.Entity<Appointment>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<Professional>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<Customer>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<Time>().Property(p => p.EntityID).ValueGeneratedNever();

            SeedData(builder);
        }

        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer() {Username = "Username1",Password = "BadPassWord21",FirstName = "Isaiah",LastName = "Smith"}
            });

            builder.Entity<Professional>().HasData(new List<Professional>
            {
                new Professional() {Username = "Speedy12",Password = "BadPassWord24",FirstName = "John",LastName = "Jacob",Title = "Blacksmith",Location = "Chicago"}
            });
        }
    }
}
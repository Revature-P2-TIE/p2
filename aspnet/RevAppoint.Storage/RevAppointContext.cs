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
                new Customer() {Username = "Username1",Password = "Password",FirstName = "Melvin",LastName = "Mac",Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "yeye@gmail.com"},
                new Customer() {Username = "trombone",Password = "Password",FirstName = "Barbara",LastName = "Gross",Gender = "M",PhoneNumber = "(773)-555-1233",EmailAddress = "rockout@gmail.com"},
                new Customer() {Username = "chicken",Password = "Password",FirstName = "Faiza",LastName = "Bowman",Gender = "F",PhoneNumber = "(773)-555-1241",EmailAddress = "playwithme@gmail.com"},
                new Customer() {Username = "foxtrail",Password = "Password",FirstName = "Nathalie",LastName = "Fellows",Gender = "M",PhoneNumber = "(773)-555-1234",EmailAddress = "REviw@gmail.com"},
                new Customer() {Username = "perseus",Password = "Password",FirstName = "Barney",LastName = "Simons",Gender = "F",PhoneNumber = "(773)-555-1144",EmailAddress = "HotBatman@gmail.com"},
                new Customer() {Username = "applepie",Password = "Password",FirstName = "Adrianna",LastName = "Prentice",Gender = "M",PhoneNumber = "(773)-555-1234",EmailAddress = "Tootoo@gmail.com"},
                new Customer() {Username = "candyfog",Password = "Password",FirstName = "Maxim",LastName = "Fowler",Gender = "M",PhoneNumber = "(773)-555-1234",EmailAddress = "harhar@gmail.com"}
            });

            builder.Entity<Professional>().HasData(new List<Professional>
            {
                new Professional() {Username = "banjojudo",Password = "BadPassword",FirstName = "Shelley",LastName = "Stacey",Title = "Blacksmith",Location = "Chicago",AppointmentLengthInHours = 1,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "giti@gmail.com"},
                new Professional() {Username = "hotdogpeas",Password = "BadPassword",FirstName = "Salgado",LastName = "Arnie",Title = "Web Developer",Location = "Las Vegas",AppointmentLengthInHours = 2,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "Tamaguchi@gmail.com"},
                new Professional() {Username = "psychobatman",Password = "BadPassword",FirstName = "Chanel",LastName = "Tamera",Title = "Driver",Location = "Las Vegas",AppointmentLengthInHours = 3,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "jquery@gmail.com"},
                new Professional() {Username = "brownbread",Password = "BadPassword",FirstName = "Lawrence",LastName = "Gregg",Title = "Nurse",Location = "New York",AppointmentLengthInHours = 1,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "HarVey@gmail.com"},
                new Professional() {Username = "oystersnatch",Password = "BadPassword",FirstName = "Ibrahim",LastName = "Elis",Title = "Barber",Location = "New York",AppointmentLengthInHours = 2,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "Lmao@gmail.com"},
                new Professional() {Username = "islandhorse",Password = "BadPassword",FirstName = "Page",LastName = "Branch",Title = "Barber",Location = "Chicago",AppointmentLengthInHours = 4,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "Vier@gmail.com"},
                new Professional() {Username = "cocktailwave",Password = "BadPassword",FirstName = "Chante",LastName = "Jacob",Title = "Web Developer",Location = "Chicago",AppointmentLengthInHours = 12,Gender = "F",PhoneNumber = "(773)-555-1234",EmailAddress = "Locomotive@gmail.com"}
            });
        }
    }
}
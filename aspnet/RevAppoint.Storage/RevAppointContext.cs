using Microsoft.EntityFrameworkCore;
using RevAppoint.Domain.POCOs;

namespace RevAppoint.Storage
{
    public class RevAppointContext : DbContext
    {
        public DbSet<Appointment> Appointment {get;set;}
        public DbSet<Professional> Professional {get;set;}
        public DbSet<Time> Time {get;set;}
        public DbSet<User> User {get;set;}

        public RevAppointContext(DbContextOptions<RevAppointContext> options) : base(options){}
        public RevAppointContext(){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Appointment>().HasKey(s => s.EntityID);
            builder.Entity<Professional>().HasKey(s => s.EntityID);
            builder.Entity<User>().HasKey(s => s.EntityID);
            builder.Entity<Time>().HasKey(s => s.EntityID);

            builder.Entity<Appointment>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<Professional>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<User>().Property(p => p.EntityID).ValueGeneratedNever();
            builder.Entity<Time>().Property(p => p.EntityID).ValueGeneratedNever();

        }
    }
}
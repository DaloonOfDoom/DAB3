using DAB2_2.Models;
using DAB2_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAB2_2.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
       
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Society> Societies { get; set; }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Code> Codes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\DAB01;Initial Catalog=DAB4;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Address>().HasKey(a => a.AddressId);
            mb.Entity<Person>().HasKey(p => p.Cpr);
            mb.Entity<Room>().HasKey(r => r.RoomId);
            mb.Entity<Society>().HasKey(s => s.Cvr);
            mb.Entity<Booking>().HasKey(b => new {b.SocietyId, b.RoomId, b.TimeStart});
            mb.Entity<Code>().HasKey(c => new {c.Pin, c.RoomId});
            mb.Entity<Key>().HasKey(k => k.KeyId);
            mb.Entity<Person>()
                .Property(p => p.Cpr)
                .ValueGeneratedNever();
            mb.Entity<Society>()
                .Property(s => s.Cvr)
                .ValueGeneratedNever();
            mb.Entity<Code>()
                .Property(c => c.Pin)
                .ValueGeneratedNever();

            mb.Entity<Room>().HasMany<Code>(r => r.Codes)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomId);

                mb.Entity<Society>().HasMany<Booking>(p => p.Bookings)
                .WithOne(cb => cb.Society)
                .HasForeignKey(cb => cb.SocietyId);

         
            mb.Entity<Room>().HasMany<Booking>(r => r.BookingList)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId);

        

        }
    }
}

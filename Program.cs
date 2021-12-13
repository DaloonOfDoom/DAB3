using System;
using System.Linq;
using DAB2_2.Data;
using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAB2_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var _ins = new Inserters();
            var _client = new MongoClient();
            var _database = _client.GetDatabase("Municipality");

            var col = _database.GetCollection<Address>("Addresses");

            var addr = new Address(8, 8200, "der", 1);
            _ins.AddAddress(addr);

            var hent = col
                        .Find(c => c.Zip == 8200)
                        .ToListAsync()
                        .Result;

            foreach( var v in hent)
            {
                Console.WriteLine($"{v.AddressId} -- {v.Zip}: {v.Street} {v.Number}");
            }

    

            //MyDbContext _context = new();
            //var loadCheck =
            //    _context.Addresses.Any();

            //if (!loadCheck)
            //{
            //    Console.WriteLine("Seeding database");
            //    var l = new Loader(_context);
            //    l.loadAddresses();
            //    l.loadPersons();
            //    l.loadSocieties();
            //    l.loadKeyholders();
            //    l.loadRooms();
            //    l.loadBookings();
            //    l.loadKeys();
            //    l.loadCodes();
            //}
            //else
            //{
            //    Console.WriteLine("Loadcheck passed");
            //}

    


            // Add queries here.
            // Possible calls are:
            // Queries.GetAllRooms(_context);
            // Queries.GetSocietiesByActivity(_context, activity);
            // Queries.GetAllbookings(_context);
            // Queries.GetBookingsBySociety(_context, societyId);

            //    Console.WriteLine("\r\n Printing Rooms\r\n");
            //    Queries.GetAllRooms(_context);
            //    Console.WriteLine("\r\n Printing Activities\r\n");
            //    Queries.GetSocietiesByActivity(_context, "Software og sjov");
            //    Console.WriteLine("\r\n Printing Bookings\r\n");
            //    Queries.GetAllBookings(_context);
            //    Console.WriteLine("\r\n");
            //    Queries.GetBookingsBySociety(_context, Queries.GetSocietyId(_context, "Norm's funhouse"));
            //}
        }
    }
}
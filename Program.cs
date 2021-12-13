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

            var filter = Builders<Address>.Filter.Where(a=> true);
            var loadCheck = col.Find(filter).Any();

            _ins.AddAddress(8200, "her", 10);

            Console.WriteLine(Queries.NextAddress());
           
            if (!loadCheck)
            {
                Console.WriteLine("Seeding database");
                //var l = new Loader();
                //l.loadAddresses();
                //l.loadPersons();
                //l.loadSocieties();
                //l.loadKeyholders();
                //l.loadRooms();
                //l.loadBookings();
                //l.loadKeys();
               // l.loadCodes();
            }
            else
            {
                Console.WriteLine("Loadcheck passed");
            }




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
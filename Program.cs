using System;
using System.Linq;
using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAB2_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("Municipality");

            var col = _database.GetCollection<Address>("Addresses");

            var filter = Builders<Address>.Filter.Where(a=> true);
            var loadCheck = col.Find(filter).Any();


            if (!loadCheck)
            {
                Console.WriteLine("Seeding database");
                var l = new Loader();
                l.loadAddresses();
                l.loadPersons();
                l.loadSocieties();
                l.loadKeyholders();
                l.loadRooms();
                l.loadBookings();
                l.loadKeys();
                l.loadCodes();
            }
            else
            {
                Console.WriteLine("Loadcheck passed");
            }




            // Add queries here.
            // Possible calls are:
            // Queries.GetAllRooms();
            // Queries.GetSocietiesByActivity(, activity);
            // Queries.GetAllbookings();
            // Queries.GetBookingsBySociety(, societyId);

           Console.WriteLine("\r\n Printing Rooms\r\n");
           Queries.GetAllRooms();
           Console.WriteLine("\r\n Printing Activities\r\n");
            Queries.GetSocietiesByActivity();
                Console.WriteLine("\r\n Printing Bookings\r\n");
            Queries.GetAllBookings();
                Console.WriteLine("\r\n Printing bookings for Person with CPR:459431\r\n");
               Queries.GetAllPersonalBookings(459431);
            //}
        }
    }
}
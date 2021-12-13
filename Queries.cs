//using System;
//using System.Linq;

using DAB2_2.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Linq;

namespace DAB2_2
{
    public class Queries
    {
        static private IMongoClient _client = new MongoClient();
        static private IMongoDatabase _database = _client.GetDatabase("Municipality");

        public static int NextAddress()
        {
            var col = _database.GetCollection<Address>("Addresses");
            var filter = Builders<Address>.Filter.Where(a => true);
            var res = ((int)col.CountDocuments(filter));
            return res;
        }
        public static int NextRoom()
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.Where(a => true);
            var res = ((int)col.CountDocuments(filter));
            return res;
        }
        public static int NextBooking()
        {
            var col = _database.GetCollection<Booking>("Bookings");
            var filter = Builders<Booking>.Filter.Where(a => true);
            var res = ((int)col.CountDocuments(filter));
            return res;
        }

        public static bool CheckPerson(Person per)
        {
            return CheckPerson(per.Cpr);
        }
        public static bool CheckPerson(int cpr)
        {
            var col = _database.GetCollection<Person>("Persons");
            var filter = Builders<Person>.Filter.Where(p => p.Cpr == cpr);
            var res = col.Find(filter).ToList<Person>();
            return res.Any();
        }

        public static bool CheckSociety(Society soc)
        {
            return CheckSociety(soc.Cvr);
        }
        public static bool CheckSociety(int cvr)
        {
            var col = _database.GetCollection<Society>("Societies");
            var filter = Builders<Society>.Filter.Where(s => s.Cvr == cvr);
            var res = col.Find(filter).ToList<Society>();
            return res.Any();
        }

        public static int GetSocietyId(Society soc)
        {
            return GetSocietyId(soc.Name);
        }
        public static int GetSocietyId(string name)
        {
            var col = _database.GetCollection<Society>("Societies");
            var filter = Builders<Society>.Filter.Where(s => s.Name == name);
            var res = col.Find(filter).FirstOrDefault<Society>();
            return res.Cvr;
        }

        public static bool CheckAddress(Address addr)
        {
            return CheckAddress(addr.Zip, addr.Street, addr.Number);
        }
        public static bool CheckAddress(int zip, string st, int nr)
        {
            var col = _database.GetCollection<Address>("Addresses");
            var filter = Builders<Address>.Filter.
                Where(a => a.Zip == zip
                    && a.Street == st
                    && a.Number == nr);
            var res = col.Find(filter).ToList<Address>();
            return res.Any();
        }

        public static bool CheckAddress(int addressId)
        {
            var col = _database.GetCollection<Address>("Addresses");
            var filter = Builders<Address>.Filter.Where(a => a.AddressId == addressId);
            var res = col.Find(filter).ToList<Address>();
            return res.Any();
        }

        public static int GetAddressId(Address addr)
        {
            return GetAddressId(addr.Zip, addr.Street, addr.Number);
        }
        public static int GetAddressId(int zip, string street, int number)
        {
            var col = _database.GetCollection<Address>("Addresses");
            var filter = Builders<Address>.Filter.Where(a => a.Zip == zip
                && a.Street == street
                && a.Number == number);
            var res = col.Find(filter).FirstOrDefault<Address>();
            return res.AddressId;
        }

        public static bool CheckRoom(Room room)
        {
            return CheckRoom(room.RoomName, room.AddressId);
        }
        public static bool CheckRoom(string name, int addr)
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.
                Where(r => r.RoomName == name
                && r.AddressId == addr);
            var res = col.Find(filter).ToList<Room>();
            return res.Any();
        }

        public static int GetRoomId(Room room)
        {
            return GetRoomId(room.RoomName, room.AddressId);
        }
        public static int GetRoomId(string roomName, int addressId)
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.Where(r => r.RoomName == roomName
                && r.AddressId == addressId);
            var res = col.Find(filter).FirstOrDefault<Room>();
            return res.RoomId;
        }

        public static bool CheckCode(Room room, int pin)
        {
            return CheckCode(room.RoomId, pin);
        }
        public static bool CheckCode(int roomId, int pin)
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.
                Where(r => r.RoomId == roomId
                && r.Codes.Contains(pin));
            var res = col.Find(filter).ToList<Room>();
            return res.Any();
        }

        public static bool CheckKey(Room room)
        {
            return CheckKey(room.RoomId);
        }
        public static bool CheckKey(int roomId)
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.
                Where(r => r.RoomId == roomId
                && r.KeyAddressId != null);
            var res = col.Find(filter).ToList<Room>();
            return res.Any();
        }


        public static bool CheckBooking(int roomId, DateTime timeStart)
        {
            var col = _database.GetCollection<Room>("Bookings");
            var filter = Builders<Room>.Filter.
                Where(b => b.RoomId == roomId
                && b.Bookings.Any(b => b.TimeStart == timeStart));
            var res = col.Find(filter).ToList<Room>();
            return res.Any();
        }

        public static bool CheckCanBook(int cvr)
        {
            var col = _database.GetCollection<Society>("Societies");
            var filter = Builders<Society>.Filter.
                Where(s => s.KeyholderId != null);
            var res = col.Find(filter).ToList<Society>();
            return res.Any();

        }
        public static bool CheckCanBook(Booking book)
        {
            return CheckCanBook(book.SocietyId);
        }


        public static void GetAllRooms()
        {
            var col = _database.GetCollection<Room>("Rooms");
            var res = col.Find(r => true).ToEnumerable();
            foreach(var r in res)
            {
                var r_col = _database.GetCollection<Address>("Addresses");
                var r_filter = Builders<Address>.Filter.Where(a => a.AddressId == r.AddressId);
                var r_res = r_col.Find(r_filter).First();

                Console.WriteLine($"{r.RoomName} : {r_res.Street} {r_res.Number} - {r_res.Zip}");

            }
        }


        public static void GetSocietiesByActivity()
        {
            var col = _database.GetCollection<Society>("Societies");
            var res = col.Find(s => true).SortBy(s => s.Activity).ToEnumerable();

            foreach(var s in res)
            {
               

                if (s.ChairmanId != null)
                {
                    var r_col = _database.GetCollection<Address>("Addresses");
                    var r_filter = Builders<Address>.Filter.Where(a => a.AddressId == s.AddressId);
                    var r_res = r_col.Find(r_filter).First();

                    var c_col = _database.GetCollection<Person>("Persons");
                    var c_filter = Builders<Person>.Filter.Where(p=>p.Cpr == s.ChairmanId);
                    var c_res = c_col.Find(c_filter).First();
                    Console.WriteLine($"{s.Activity} - {s.Name}, {s.Cvr}: {r_res.Zip}, {r_res.Street} {r_res.Number}, Chairman is: {c_res.FirstName} {c_res.LastName}");
                }
                else
                {
                    var r_col = _database.GetCollection<Address>("Addresses");
                    var r_filter = Builders<Address>.Filter.Where(a => a.AddressId == s.AddressId);
                    var r_res = r_col.Find(r_filter).First();

                    Console.WriteLine($"{s.Activity} - {s.Name}, {s.Cvr}: {r_res.Zip}, {r_res.Street} {r_res.Number}");
                }

            }
         }

        public static void GetAllBookings()
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.Where(r => r.Bookings.Count() >= 1);
            var res = col.Find(filter).ToEnumerable();

            foreach(var r in res)
            {
                var a_col = _database.GetCollection<Address>("Addresses");
                    var a_filter = Builders<Address>.Filter.Where(a => a.AddressId == r.AddressId);
                    var a = a_col.Find(a_filter).First();
                Console.WriteLine($"Room: {r.RoomName} at {a.Street} {a.Number} - {a.Zip} has been booked {r.Bookings.Count()} times:");
                foreach(var b in r.Bookings)
                {
                    var s_col = _database.GetCollection<Society>("Societies");
                    var s = s_col.Find(s => s.Cvr == b.SocietyId).First();

                    var c_col = _database.GetCollection<Person>("Persons");
                    var c_filter = Builders<Person>.Filter.Where(p => p.Cpr == s.ChairmanId);
                    var c = c_col.Find(c_filter).FirstOrDefault();

                    if (c!= null)
                    {
                        Console.WriteLine($"{b.TimeStart.ToString("d")} by {s.Name} with chairman {c.FirstName} {c.LastName}");
                    }
                    else Console.WriteLine($"{b.TimeStart.ToString("d")} by {s.Name}");


                }


                

            }
        }

        public static void GetAllPersonalBookings(int cpr)
        {
            var col = _database.GetCollection<Room>("Rooms");
            var filter = Builders<Room>.Filter.Where(r => r.Bookings.
            Any(b=>b.KeyholderId == cpr
            && b.TimeStart >= DateTime.Now));
            var res = col.Find(filter).ToEnumerable();
            foreach(var r in res)
            {
                var a_col = _database.GetCollection<Address>("Addresses");
                var a_filter = Builders<Address>.Filter.Where(a => a.AddressId == r.AddressId);
                var a = a_col.Find(a_filter).First();

                Console.WriteLine($"Room: {r.RoomName} at {a.Street} {a.Number} - {a.Zip} can by accessed by:");
                if(r.KeyAddressId != null)
                {
                    var k_col = _database.GetCollection<Address>("Addresses");
                    var k_filter = Builders<Address>.Filter.Where(a => a.AddressId == r.KeyAddressId);
                    var k = k_col.Find(k_filter).First();
                    Console.WriteLine();
                    Console.WriteLine($"Key: can be accessed at {k.Street} {k.Number} - {k.Zip}");
                }

                if(r.Codes.Count() > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Code:");

                    foreach(var c in r.Codes)
                    {
                        Console.WriteLine($"PIN: {c}");
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Is booked on the following days:");

                foreach(var b in r.Bookings)
                {
                    Console.WriteLine($"{b.TimeStart.ToString("d")}");
                }
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("");
            }
        }
        //          
    }
}


//        ////Returns Id og Address. Returns 0 if not found.
//        //public static int GetAddressId(MyDbContext context, int zip, string street, int nmbr)
//        //{
//        //    return context.Addresses.FirstOrDefault(a =>
//        //        a.Zip == zip
//        //        && a.Street == street
//        //        && a.Number == nmbr
//        //    )?.AddressId ?? "0";
//        //}

//        public static int GetAddressId(MyDbContext context, Address adr)
//        {
//            return GetAddressId(context, adr.Zip, adr.Street, adr.Number);
//        }

//        public static int GetSocietyId(MyDbContext context, string name)
//        {
//            return context.Societies.FirstOrDefault(s =>
//                s.Name == name)?.Cvr ?? 0;
//        }

//        public static int GetSocietyId(MyDbContext context, Society soc)
//        {
//            return GetSocietyId(context, soc.Name);
//        }

//        public static int GetPersonId(MyDbContext context, string firstName, string lastName, int addrId)
//        {
//            return context.Persons.FirstOrDefault(p =>
//                p.FirstName == firstName
//                && p.LastName == lastName
//                && p.AddressId == addrId)?.Cpr ?? 0;
//        }

//        public static int GetPersonId(MyDbContext context, Person per)
//        {
//            return GetPersonId(context, per.FirstName, per.FirstName, per.AddressId);
//        }

//        public static int GetRoomId(MyDbContext context, string name, int addr)
//        {
//            return context.Rooms.FirstOrDefault(r =>
//                r.RoomName == name
//                && r.AddressId == addr)?.RoomId ?? 0;
//        }

//        public static int GetRoomId(MyDbContext context, Room room)
//        {
//            return GetRoomId(context, room.RoomName, room.AddressId);
//        }

//        public static bool CheckCanBook(MyDbContext context, int societyId)
//        {
//            return context.Societies.Where(s =>
//                s.Cvr == societyId).Select(s => s.KeyholderId) != null;
//        }

//        public static bool CheckAddress(MyDbContext context, int addressId)
//        {
//            return context.Addresses.Any(a =>
//                a.AddressId == addressId);
//        }

//        public static bool CheckBooking(MyDbContext context, int personId, int societyId, int roomId, DateTime start)
//        {
//            if (CheckCanBook(context, societyId))
//                return context.Bookings.Any(b =>
//                    b.SocietyId == societyId
//                    && b.RoomId == roomId
//                    && b.TimeStart == start);

//            return true;
//        }

//        public static bool CheckPerson(MyDbContext context, int personId)
//        {
//            return context.Persons.Any(p =>
//                p.Cpr == personId);
//        }

//        public static bool CheckSociety(MyDbContext context, int societyId)
//        {
//            return context.Societies.Any(s =>
//                s.Cvr == societyId);
//        }

//        public static bool CheckSociety(MyDbContext context, string name)
//        {
//            return context.Societies.Any(s =>
//                s.Name == name);
//        }

//        public static int GetKeyId(MyDbContext context, int roomId)
//        {
//            return context.Keys.FirstOrDefault(k =>
//                k.RoomId == roomId)?.KeyId ?? 0;
//        }

//        public static bool CheckRoom(MyDbContext context, int roomId)
//        {
//            return context.Rooms.Any(r =>
//                r.RoomId == roomId);
//        }

//        public static bool CheckKeyholder(MyDbContext context, int personId)
//        {
//            return context.Persons.Any(p =>
//                p.Cpr == personId
//                && p.License != null
//                && p.Phonenumber != null);
//        }

//        public static bool CheckCode(MyDbContext context, int pin, int roomId)
//        {
//            return context.Codes.Any(c =>
//                c.Pin == pin
//                && c.RoomId == roomId);
//        }

//        public static void GetAllRooms(MyDbContext context)
//        {
//            var list = from r in context.Rooms
//                select new
//                {
//                    r.RoomName,
//                    r.Address.Street,
//                    r.Address.Zip,
//                    r.Address.Number
//                };

//            foreach (var r in list) Console.WriteLine($"{r.RoomName}: {r.Zip}, {r.Street} {r.Number}");
//        }

        
//        public static void GetAllBookings(MyDbContext context)
//        {
//            var list = context.Bookings
//                .Include(b => b.Society)
//                .ThenInclude(s => s.Chairman)
//                .Include(b => b.Room)
//                .AsEnumerable()
//                .GroupBy(b => b.RoomId);

//            foreach (var q in list)k
//            {
//                Console.WriteLine($"Room: {q.Key}, booed {q.Count()} time(s)");

//                foreach (var b in q)
//                    if (b.Society.Chairman?.FirstName == null)
//                        Console.WriteLine(
//                            $"Booked by {b.Society.Name} starting at {b.TimeStart}");
//                    else
//                        Console.WriteLine(
//                            $"Booked by {b.Society.Name} with Chairman {b.Society.Chairman.FirstName} {b.Society.Chairman.LastName}, starting at {b.TimeStart}");
//            }
//        }

//        public static void GetBookingsBySociety(MyDbContext context, int cvr)
//        {
//            var list = context.Bookings
//                .Include(b => b.Room)
//                .ThenInclude(r => r.Address)
//                .Include(b => b.Room)
//                .ThenInclude(r => r.Key)
//                .ThenInclude(k => k.Address)
//                .Include(b => b.Room)
//                .ThenInclude(r => r.Codes)
//                .Where(s => s.SocietyId == cvr
//                            && s.TimeStart >= DateTime.Today)
//                .AsEnumerable();

//            Console.WriteLine($"Printing all future bookings for Society: {cvr}: ");
//            if (!list.Any()) Console.WriteLine("No future bookings");
//            else
//                foreach (var r in list)
//                {
//                    Console.WriteLine(
//                        $"Room: {r.Room.RoomName} at {r.Room.Address.Street} {r.Room.Address.Number}, {r.Room.Address.Zip} is booked on {r.TimeStart}");
//                    Console.WriteLine("It can be accessed by:");
//                    Console.WriteLine("");

//                    if (r.Room.Key != null)
//                    {
//                        Console.WriteLine("Key:");
//                        Console.WriteLine(
//                            $"You can collect/drop off the key at {r.Room.Key.Address.Street} {r.Room.Key.Address.Number}, {r.Room.Key.Address.Zip}");
//                        Console.WriteLine("");
//                    }

//                    if (r.Room.Codes.Count != 0)
//                    {
//                        Console.WriteLine("Code(s)");
//                        foreach (var c in r.Room.Codes) Console.WriteLine($"{c.Pin}");
//                        Console.WriteLine("");
//                    }
//                }
//        }
//    }
//}
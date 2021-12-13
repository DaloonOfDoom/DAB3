using System;
using System.Linq;
using DAB2_2.Data;
using DAB2_2.Models;
using DAB2_3.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAB2_2
{
    public class Inserters
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public Inserters()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("Municipality");
        }


        //Adds address to db. Returns Id of new address. Returns Id of address if it already exists.
        public int AddAddress(int addressId, int zip, string street, int nmbr)
        {
            return AddAddress(new Address(addressId,zip, street, nmbr));
        }

        public int AddAddress(Address adr)
        {
            var col = _database.GetCollection<Address>("Addresses");

            if (col.Find(x => x.AddressId == adr.AddressId).ToString() == null)
            {
                col.InsertOne(adr);

                return 1;
            }
            Console.WriteLine()
            var check = col.Find<Address>(x => x.AddressId == adr.AddressId).ToList();
            foreach(var r in check)
            {
               
                Console.WriteLine($"{r.AddressId} {r.ObjId} ");
            }
            Console.WriteLine("double i address");
            return 0;
        }

        public int AddSociety(int cvr, string name, string activity, int addr, int? chairman = null)
        {
            return AddSociety(new Society(cvr, name, activity, addr, chairman));
        }

        public int AddSociety(Society s)
        {
            var col = _database.GetCollection<Society>("Societies");
            col.InsertOne(s);
           
            return 1;
        }
    }
}


//        public int AddSociety(Society soc)
//        {
//            if (Queries.GetSocietyId(_context, soc) == 0)
//            {
//                if (soc.KeyholderId != null && !Queries.CheckKeyholder(_context, (int)soc.KeyholderId))
//                    soc.KeyholderId = null;

//                _context.Add(soc);
//                _context.SaveChanges();
//            }

//            return Queries.GetSocietyId(_context, soc);
//        }

//        public int AddSociety(int cvr, string name, string activity, int addr, int? chairman = null,
//            int? keyholder = null)
//        {
//            return AddSociety(new Society(cvr, name, activity, addr, chairman, keyholder));
//        }

//        public int AddKeyholder(int cvr, Person person)
//        {
//            if (!Queries.CheckSociety(_context, cvr) || person.License == null || person.Phonenumber == null) return 0;

//            var res = _context.Persons.SingleOrDefault(p =>
//                p.Cpr == person.Cpr);
//            if (res == null)
//            {
//                AddPerson(person);
//            }
//            else
//            {
//                res.License = person.License;
//                res.Phonenumber = person.Phonenumber;
//                _context.SaveChanges();
//            }

//            var soc = _context.Societies.SingleOrDefault(s =>
//                s.Cvr == cvr);
//            soc.KeyholderId = person.Cpr;
//            _context.SaveChanges();
//            return 1;
//        }

//        public int AddKeyholder(int cvr, int cpr, string firstName, string lastName, int addr, int? license = null,
//            int? phonenumber = null)
//        {
//            return AddKeyholder(cvr, new Person(cpr, firstName, lastName, addr, license, phonenumber));
//        }

//        public int AddKeyholder(int cvr, int cpr)
//        {
//            if (!Queries.CheckSociety(_context, cvr) || !Queries.CheckKeyholder(_context, cpr)) return 0;
//            var soc = _context.Societies.SingleOrDefault(s =>
//                s.Cvr == cvr);
//            soc.KeyholderId = cpr;
//            _context.SaveChanges();
//            return 1;
//        }

//        public int AddPerson(Person per)
//        {
//            if (!Queries.CheckPerson(_context, per.Cpr))
//            {
//                _context.Add(per);
//                _context.SaveChanges();
//            }

//            return per.Cpr;
//        }

//        public int AddPerson(int cpr, string firstName, string lastName, int addr, int? license = null,
//            int? phonenumber = null)
//        {
//            return AddPerson(new Person(cpr, firstName, lastName, addr, license, phonenumber));
//        }

//        public int AddRoom(Room room)
//        {
//            if (Queries.GetRoomId(_context, room) == 0)
//            {
//                _context.Add(room);
//                _context.SaveChanges();
//            }

//            return Queries.GetRoomId(_context, room);
//        }

//        public int AddRoom(string name, int max, int opening, int closing, int addr)
//        {
//            return AddRoom(new Room(name, max, opening, closing, addr));
//        }


//        //Returns 1 if booking is successful
//        public int AddBooking(int personId, int societyId, int roomId, DateTime start)
//        {
//            if (Queries.CheckRoom(_context, roomId)
//                && !Queries.CheckBooking(_context, personId, societyId, roomId, start))
//            {
//                _context.Add(new Booking(societyId, roomId, start));
//                _context.SaveChanges();
//                return 1;
//            }

//            return 0;
//        }

//        public int AddCode(int pin, int roomId)
//        {
//            if (!Queries.CheckCode(_context, pin, roomId)
//                && Queries.CheckRoom(_context, roomId))
//            {
//                _context.Add(new Code(pin, roomId));
//                _context.SaveChanges();
//                return 1;
//            }

//            return 0;
//        }

//        public int AddKey(int roomId, int addressId)
//        {
//            if (Queries.GetKeyId(_context, roomId) == 0
//                && Queries.CheckRoom(_context, roomId)
//                && Queries.CheckAddress(_context, addressId))

//            {
//                _context.Add(new Key(roomId, addressId));
//                _context.SaveChanges();
//            }

//            return Queries.GetKeyId(_context, roomId);
//        }
//    }
//}
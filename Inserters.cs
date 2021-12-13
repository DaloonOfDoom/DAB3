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
            return AddAddress(new Address(addressId, zip, street, nmbr));
        }

        public int AddAddress(Address adr)
        {
            var col = _database.GetCollection<Address>("Addresses");
            var filter = Builders<Address>.Filter.Where(x => x.AddressId == adr.AddressId
                                                            );
            var res = col.Find(filter).ToList<Address>();
            if (!res.Any())
            {
                col.InsertOne(adr);

                return 1;
            }
            return 0;
        }

        //not done
        public int AddSociety(Society soc)
        {
            if (!Queries.CheckSociety(soc))
            {
                if (soc.KeyholderId != null && !Queries.CheckKeyholder(_context, (int)soc.KeyholderId))
                    soc.KeyholderId = null;

                return 1;
            }

            return 0;
        }

        public int AddSociety(int cvr, string name, string activity, int addr, int? chairman = null,
            int? keyholder = null)
        {
            return AddSociety(new Society(cvr, name, activity, addr, chairman, keyholder));
        }

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

        public int AddPerson(Person per)
        {
            var col = _database.GetCollection<Person>("Persons");
            if (!Queries.CheckPerson(per))
            {
                col.InsertOne(per);

                return 1;
            }

            return 0;
        }

        public int AddPerson(int cpr, string firstName, string lastName, int addr, int? license = null,
            int? phonenumber = null)
        {
            return AddPerson(new Person(cpr, firstName, lastName, addr, license, phonenumber));
        }

        public int AddRoom(Room room)
        {
            var col = _database.GetCollection<Room>("Rooms");
            if (!Queries.CheckRoom(room))
            {
                col.InsertOne(room);
                return 1;
            }

            return 0;
        }

        public int AddRoom(int roomId, string name, int max, int opening, int closing, int addr)
        {
            return AddRoom(new Room(roomId, name, max, opening, closing, addr));
        }

        public int AddBooking(int bookingId, int societyId, int roomId, DateTime start)
        {
            return AddBooking(new Booking(bookingId, societyId, roomId, start));
        }

        //Returns 1 if booking is successful
        public int AddBooking(Booking book)
        {
            var col = _database.GetCollection<Booking>("Bookings");
            if (!Queries.CheckBookings(book))
            {
                col.InsertOne(book);
                return 1;
            }
            return 0;
        }


        //public int AddCode(int pin, int roomId)
        //{
        //    if (!Queries.CheckCode(_context, pin, roomId)
        //        && Queries.CheckRoom(_context, roomId))
        //    {
        //        _context.Add(new Code(pin, roomId));
        //        _context.SaveChanges();
        //        return 1;
        //    }

        //    return 0;
        //}

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
    }
}
using System;
using System.Linq;
//using DAB2_2.Data;
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
        public int AddAddress(int zip, string street, int nmbr)
        {
            return AddAddress(new Address(0, zip, street, nmbr));
        }

        public int AddAddress(Address adr)
        {
            var col = _database.GetCollection<Address>("Addresses");
            if (!Queries.CheckAddress(adr))
            {

                adr.AddressId = Queries.NextAddress();
                col.InsertOne(adr);

                return 1;
            }
            return 0;
        }

        //not done
        public int AddSociety(Society soc)
        {
            var col = _database.GetCollection<Society>("Societies");
            if (!Queries.CheckSociety(soc))
            {
                col.InsertOne(soc);

                return 1;
            }

            return 0;
        }

        public int AddSociety(int cvr, string name, string activity, int addr, int? chairman = null,
            int? keyholder = null)
        {
            return AddSociety(new Society(cvr, name, activity, addr, chairman, keyholder));
        }

        public int AddKeyholder(int cvr, Person person)
        {
            return AddKeyholder(cvr, person.Cpr);
        }


        public int AddKeyholder(int cvr, int cpr)
        {
            if (Queries.CheckSociety(cvr) && !Queries.CheckCanBook(cvr) && Queries.CheckPerson(cpr))
            {
                var col = _database.GetCollection<Society>("Societies");
                var filter = Builders<Society>.Filter.Eq("Cvr", cvr);
                var update = Builders<Society>.Update.Set("KeyholderId", cpr);
                col.UpdateOne(filter, update);
                return 1;
            }
            return 0;
        }

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
                room.RoomId = Queries.NextRoom();
                col.InsertOne(room);
                return 1;
            }

            return 0;
        }

        public int AddRoom(string name, int max, int opening, int closing, int addr)
        {
            return AddRoom(new Room(0, name, max, opening, closing, addr));
        }

        public int AddBooking(int societyId, int roomId, DateTime start)
        {
            return AddBooking(new Booking(0, societyId, roomId, start));
        }

        //Returns 1 if booking is successful
        public int AddBooking(Booking book)
        {

            var col = _database.GetCollection<Booking>("Bookings");
            if (!Queries.CheckBooking(book))
            {
                book.BookingId = Queries.NextBooking();
                col.InsertOne(book);
                return 1;
            }
            return 0;
        }

        public int AddKey(int roomId, int addressId)
        {
            if (Queries.CheckAddress(addressId))
            {
                if (!Queries.CheckKey(roomId))
                {
                    var col = _database.GetCollection<Room>("Rooms");
                    var filter = Builders<Room>.Filter.Eq("RoomId", roomId);
                    var update = Builders<Room>.Update.Set("Key", addressId);
                    col.UpdateOne(filter, update);
                    return 1;
                }
            }
            return 0;
        }

        public int AddCode()
        {

        }


        //public int AddCode(int pin, int roomId)
        //{
        //    if (!Queries.CheckCode(, pin, roomId)
        //        && Queries.CheckRoom(, roomId))
        //    {
        //        .Add(new Code(pin, roomId));
        //        .SaveChanges();
        //        return 1;
        //    }

        //    return 0;
        //}

        //        public int AddKey(int roomId, int addressId)
        //        {
        //            if (Queries.GetKeyId(, roomId) == 0
        //                && Queries.CheckRoom(, roomId)
        //                && Queries.CheckAddress(, addressId))

        //            {
        //                .Add(new Key(roomId, addressId));
        //                .SaveChanges();
        //            }

        //            return Queries.GetKeyId(, roomId);
        //        }
    }
}
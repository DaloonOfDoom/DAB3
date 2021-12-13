using System;
using System.Linq;
using DAB2_2.Data;
using DAB2_2.Models;
using DAB2_3.Models;

namespace DAB2_2
{
    public class Inserters
    {
        private readonly MyDbContext _context;

        public Inserters(MyDbContext context)
        {
            _context = context;
        }

        //Adds address to db. Returns Id of new address. Returns Id of address if it already exists.
        public int AddAddress(int zip, string street, int nmbr)
        {
            return AddAddress(new Address(zip, street, nmbr));
        }

        public int AddAddress(Address adr)
        {
            if (Queries.GetAddressId(_context, adr) == 0)
            {
                _context.Add(adr);
                _context.SaveChanges();
            }

            return Queries.GetAddressId(_context, adr);
        }

        public int AddSociety(Society soc)
        {
            if (Queries.GetSocietyId(_context, soc) == 0)
            {
                if (soc.KeyholderId != null && !Queries.CheckKeyholder(_context, (int) soc.KeyholderId))
                    soc.KeyholderId = null;

                _context.Add(soc);
                _context.SaveChanges();
            }

            return Queries.GetSocietyId(_context, soc);
        }

        public int AddSociety(int cvr, string name, string activity, int addr, int? chairman = null,
            int? keyholder = null)
        {
            return AddSociety(new Society(cvr, name, activity, addr, chairman, keyholder));
        }

        public int AddKeyholder(int cvr, Person person)
        {
            if (!Queries.CheckSociety(_context, cvr) || person.License == null || person.Phonenumber == null) return 0;

            var res = _context.Persons.SingleOrDefault(p =>
                p.Cpr == person.Cpr);
            if (res == null)
            {
                AddPerson(person);
            }
            else
            {
                res.License = person.License;
                res.Phonenumber = person.Phonenumber;
                _context.SaveChanges();
            }

            var soc = _context.Societies.SingleOrDefault(s =>
                s.Cvr == cvr);
            soc.KeyholderId = person.Cpr;
            _context.SaveChanges();
            return 1;
        }

        public int AddKeyholder(int cvr, int cpr, string firstName, string lastName, int addr, int? license = null,
            int? phonenumber = null)
        {
            return AddKeyholder(cvr, new Person(cpr, firstName, lastName, addr, license, phonenumber));
        }

        public int AddKeyholder(int cvr, int cpr)
        {
            if (!Queries.CheckSociety(_context, cvr) || !Queries.CheckKeyholder(_context, cpr)) return 0;
            var soc = _context.Societies.SingleOrDefault(s =>
                s.Cvr == cvr);
            soc.KeyholderId = cpr;
            _context.SaveChanges();
            return 1;
        }

        public int AddPerson(Person per)
        {
            if (!Queries.CheckPerson(_context, per.Cpr))
            {
                _context.Add(per);
                _context.SaveChanges();
            }

            return per.Cpr;
        }

        public int AddPerson(int cpr, string firstName, string lastName, int addr, int? license = null,
            int? phonenumber = null)
        {
            return AddPerson(new Person(cpr, firstName, lastName, addr, license, phonenumber));
        }

        public int AddRoom(Room room)
        {
            if (Queries.GetRoomId(_context, room) == 0)
            {
                _context.Add(room);
                _context.SaveChanges();
            }

            return Queries.GetRoomId(_context, room);
        }

        public int AddRoom(string name, int max, int opening, int closing, int addr)
        {
            return AddRoom(new Room(name, max, opening, closing, addr));
        }


        //Returns 1 if booking is successful
        public int AddBooking(int personId, int societyId, int roomId, DateTime start)
        {
            if (Queries.CheckRoom(_context, roomId)
                && !Queries.CheckBooking(_context, personId, societyId, roomId, start))
            {
                _context.Add(new Booking(societyId, roomId, start));
                _context.SaveChanges();
                return 1;
            }

            return 0;
        }

        public int AddCode(int pin, int roomId)
        {
            if (!Queries.CheckCode(_context, pin, roomId)
                && Queries.CheckRoom(_context, roomId))
            {
                _context.Add(new Code(pin, roomId));
                _context.SaveChanges();
                return 1;
            }

            return 0;
        }

        public int AddKey(int roomId, int addressId)
        {
            if (Queries.GetKeyId(_context, roomId) == 0
                && Queries.CheckRoom(_context, roomId)
                && Queries.CheckAddress(_context, addressId))

            {
                _context.Add(new Key(roomId, addressId));
                _context.SaveChanges();
            }

            return Queries.GetKeyId(_context, roomId);
        }
    }
}
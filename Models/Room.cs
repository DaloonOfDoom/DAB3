using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAB2_3.Models;

namespace DAB2_2.Models
{
    public class Room
    {
        public Room(string roomName, int maximumOccupancy, int openingHour, int closingHour, int addressId)
        {
            RoomName = roomName;
            MaximumOccupancy = maximumOccupancy;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            AddressId = addressId;
        }

        public int RoomId { get; set; }

        [MaxLength(64)] public string RoomName { get; set; }

        public int MaximumOccupancy { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public List<Booking> BookingList { get; set; }
        public List<Code>? Codes { get; set; }
        public Key? Key { get; set; }
    }
}
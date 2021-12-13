using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Booking
    {
        public Booking(int bookingId, int societyId, int roomId, DateTime timeStart, string? objId = null)
        {
            ObjId = objId;
            BookingId = bookingId;
            SocietyId = societyId;
            RoomId = roomId;
            TimeStart = timeStart;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjId { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        public int SocietyId { get; set; }

        public DateTime TimeStart { get; set; }

    }
}
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Booking
    {
        public Booking(string societyId, string roomId, DateTime timeStart)
        {
            SocietyId = societyId;
            RoomId = roomId;
            TimeStart = timeStart;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string SocietyId { get; set; }

        public DateTime TimeStart { get; set; }

        public Room Room { get; set; }

        public Society Society { get; set; }
    }
}
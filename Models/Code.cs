using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_3.Models
{
    public class Code
    {
        public Code(int pin, string roomId)
        {
            Pin = pin;
            RoomId = roomId;
        }

        public int Pin { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }

        public Room Room { get; set; }
    }
}
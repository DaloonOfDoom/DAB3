using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_3.Models
{
    public class Key
    {
        public Key(string roomId, string addressId)
        {
            RoomId = roomId;
            AddressId = addressId;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string KeyId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string AddressId { get; set; }

        public Room Room { get; set; }
        public Address Address { get; set; }
    }
}
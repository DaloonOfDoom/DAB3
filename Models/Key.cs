using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_3.Models
{
    public class Key
    {
        public Key(int keyId, int roomId, int addressId, string? objId = null)
        {
            ObjId = objId;
            KeyId = keyId;
            RoomId = roomId;
            AddressId = addressId;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjId { get; set; }
        public int KeyId { get; set; }
        public int RoomId { get; set; }
        public int AddressId { get; set; }

        public Room Room { get; set; }
        public Address Address { get; set; }
    }
}
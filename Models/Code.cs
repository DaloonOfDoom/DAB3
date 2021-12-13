using DAB2_2.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_3.Models
{
    public class Code
    {
        public Code(int codeId, int pin, int roomId, string? objId = null)
        {
            ObjId = objId;
            CodeId = codeId;
            Pin = pin;
            RoomId = roomId;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjId { get; set; }
        public int CodeId { get; set; }
        public int Pin { get; set; }
        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
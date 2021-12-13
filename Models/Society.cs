using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Society
    {
        public Society(string objId, int cvr, string name, string activity, int addressId, int? chairmanId = null,
            int? keyholderId = null)
        {
            ObjId = objId;
            Cvr = cvr;
            Name = name;
            Activity = activity;
            AddressId = addressId;
            ChairmanId = chairmanId;
            KeyholderId = keyholderId;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjId { get; set; }

        public int Cvr { get; set; }

        [MaxLength(64)] public string Name { get; set; }

        [MaxLength(64)] public string Activity { get; set; }

        public int AddressId { get; set; }
        public int? ChairmanId { get; set; }
        public int? KeyholderId { get; set; }

        public Address Address { get; set; }
        public Person? Chairman { get; set; }
        public Person? Keyholder { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Society
    {
        public Society(string cvr, string name, string activity, string addressId, string? chairmanId = null,
            string? keyholderId = null)
        {
            Cvr = cvr;
            Name = name;
            Activity = activity;
            AddressId = addressId;
            ChairmanId = chairmanId;
            KeyholderId = keyholderId;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Cvr { get; set; }

        [MaxLength(64)] public string Name { get; set; }

        [MaxLength(64)] public string Activity { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AddressId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ChairmanId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string? KeyholderId { get; set; }

        public Address Address { get; set; }
        public Person? Chairman { get; set; }
        public Person? Keyholder { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
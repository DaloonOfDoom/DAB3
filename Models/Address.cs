using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Address
    {
        public Address(int addressId,int zip, string street, int number, string? objId = null)
        {
            ObjId = objId;
            AddressId = addressId;  
            Zip = zip;
            Street = street;
            Number = number;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjId { get; set; }

        public int AddressId { get; set; }
        
        public int Zip { get; set; }

        [MaxLength(64)] public string Street { get; set; }

        public int Number { get; set; }
    }
}
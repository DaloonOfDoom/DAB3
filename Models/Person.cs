using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Person
    {
        public Person(string cpr, string firstName, string lastName, string addressId, int? license = null,
            int? phonenumber = null)
        {
            Cpr = cpr;
            FirstName = firstName;
            LastName = lastName;
            AddressId = addressId;
            License = license;
            Phonenumber = phonenumber;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Cpr { get; set; }

        [MaxLength(64)] public string FirstName { get; set; }

        [MaxLength(64)] public string LastName { get; set; }

        public int? License { get; set; }
        public int? Phonenumber { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
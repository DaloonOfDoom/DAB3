using System.ComponentModel.DataAnnotations;

namespace DAB2_2.Models
{
    public class Person
    {
        public Person(int cpr, string firstName, string lastName, int addressId, int? license = null,
            int? phonenumber = null)
        {
            Cpr = cpr;
            FirstName = firstName;
            LastName = lastName;
            AddressId = addressId;
            License = license;
            Phonenumber = phonenumber;
        }

        public int Cpr { get; set; }

        [MaxLength(64)] public string FirstName { get; set; }

        [MaxLength(64)] public string LastName { get; set; }

        public int? License { get; set; }
        public int? Phonenumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DAB2_2.Models
{
    public class Address
    {
        public Address(int zip, string street, int number)
        {
            Zip = zip;
            Street = street;
            Number = number;
        }

        public int AddressId { get; set; }
        public int Zip { get; set; }

        [MaxLength(64)] public string Street { get; set; }

        public int Number { get; set; }
    }
}
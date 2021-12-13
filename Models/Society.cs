using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2_2.Models
{
    public class Society
    {
        public Society(int cvr, string name, string activity, int addressId, int? chairmanId = null,
            int? keyholderId = null)
        {
            Cvr = cvr;
            Name = name;
            Activity = activity;
            AddressId = addressId;
            ChairmanId = chairmanId;
            KeyholderId = keyholderId;
        }

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
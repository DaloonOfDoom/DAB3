using DAB2_2.Models;

namespace DAB2_3.Models
{
    public class Key
    {
        public Key(int roomId, int addressId)
        {
            RoomId = roomId;
            AddressId = addressId;
        }

        public int KeyId { get; set; }
        public int RoomId { get; set; }
        public int AddressId { get; set; }

        public Room Room { get; set; }
        public Address Address { get; set; }
    }
}
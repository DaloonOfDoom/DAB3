using DAB2_2.Models;

namespace DAB2_3.Models
{
    public class Code
    {
        public Code(int pin, int roomId)
        {
            Pin = pin;
            RoomId = roomId;
        }

        public int Pin { get; set; }
        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
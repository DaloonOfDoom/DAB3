using System;

namespace DAB2_2.Models
{
    public class Booking
    {
        public Booking(int societyId, int roomId, DateTime timeStart)
        {
            SocietyId = societyId;
            RoomId = roomId;
            TimeStart = timeStart;
        }

        public int RoomId { get; set; }

        public int SocietyId { get; set; }

        public DateTime TimeStart { get; set; }

        public Room Room { get; set; }

        public Society Society { get; set; }
    }
}
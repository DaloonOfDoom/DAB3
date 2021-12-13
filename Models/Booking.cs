using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Booking
    {
        public Booking(int keyholderId,  int societyId,DateTime timeStart)
        {
            KeyholderId = keyholderId;
            SocietyId = societyId;
            TimeStart = timeStart;
        }

        public int KeyholderId { get; set; }
        public int SocietyId { get; set; }

        public DateTime TimeStart { get; set; }

    }
}
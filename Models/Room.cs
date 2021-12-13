using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAB2_3.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB2_2.Models
{
    public class Room
    {
        public Room(int roomId, string roomName, int maximumOccupancy, int openingHour, int closingHour, int addressId, int[]? codes = null, int? keyAddressId = null, string? objId = null)
        {
            ObjId = objId;
            RoomId = roomId;
            RoomName = roomName;
            MaximumOccupancy = maximumOccupancy;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            AddressId = addressId;
            KeyAddressId = keyAddressId;
            Codes = codes;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjId { get; set; }

        public int RoomId { get; set; }

        [MaxLength(64)] public string RoomName { get; set; }

        public int MaximumOccupancy { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }

        public int AddressId { get; set; }
        public int? KeyAddressId { get; set; }
        public int[]? Codes { get; set; }

    }
}
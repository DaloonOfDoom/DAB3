//using System;
//using DAB2_2.Data;

//namespace DAB2_2
//{
//    internal class Loader
//    {
//        private readonly Inserters _ins;

//        private readonly string[] streetsList =
//        {
//            "Mean Street", "Main Street",
//            "Finlandsgade", "Meryl Street", "Vibevej", "Genvejen",
//            "Afvejen", "Sesame Street", "Food Street", "Fun Avn", "Hush Blv"
//        };


//        public Loader()
//        {
//            _ins = new Inserters();
//        }

//        public void loadAddresses()
//        {
//            for (var i = 0; i < streetsList.Length; i++) _ins.AddAddress(8200, streetsList[i], i * 2 + 1);
//        }

//        public void loadPersons()
//        {
//            _ins.AddPerson(291235, "Frikard", "Ellemand", _ins.AddAddress(8200, streetsList[0], 1));
//            _ins.AddPerson(1283751, "Steen", "Haahr", _ins.AddAddress(8200, streetsList[1], 3));
//            _ins.AddPerson(853492, "Hugh", "Jazz", _ins.AddAddress(8200, streetsList[2], 5));
//            _ins.AddPerson(12399534, "Biggus", "Dickus", _ins.AddAddress(8200, streetsList[3], 7));
//            _ins.AddPerson(1239543, "Dixie", "Normus", _ins.AddAddress(8200, streetsList[4], 9));
//            _ins.AddPerson(459431, "Turd", "Ferguson", _ins.AddAddress(8200, streetsList[5], 11), 84, 70121416);
//            _ins.AddPerson(854339, "Jenny", "Tulls", _ins.AddAddress(8200, streetsList[6], 13), 8008, 63615);
//            _ins.AddPerson(755432, "Sadie", "Enword", _ins.AddAddress(8200, streetsList[7], 15));
//            _ins.AddPerson(854310, "Lord", "Humungus", _ins.AddAddress(8200, streetsList[8], 17), 007, 20006177);
//            _ins.AddPerson(92359123, "Mathias", "Brunfarm", _ins.AddAddress(8200, "Gøteborg Alle", 14));
//        }

//        public void loadSocieties()
//        {
//            _ins.AddSociety(104104, "Norm's funhouse", "Jokes and such", _ins.AddAddress(8200, streetsList[9], 19),
//                459431);
//            _ins.AddSociety(004, "Anonymous", "Secret stuff", _ins.AddAddress(8200, streetsList[10], 21), null, 854339);
//            _ins.AddSociety(1337, "Kodeklubben", "Software og sjov", _ins.AddAddress(8200, "Finlandsgade", 22),
//                92359123);
//        }

//        public void loadKeyholders()
//        {
//            _ins.AddKeyholder(104104, 459431);
//        }

//        public void loadRooms()
//        {
//            _ins.AddRoom("430", 60, 0, 23, _ins.AddAddress(8200, "Finlandsgade", 22));
//            _ins.AddRoom("Kælderen", 100, 14, 02, _ins.AddAddress(8200, "Finlandsgade", 22));
//            _ins.AddRoom("Fælleren", 200, 12, 02, _ins.AddAddress(8200, "Gøteborg Alle", 14));
//        }


//        public void loadBookings()
//        {
//            _ins.AddBooking(459431, Queries.GetSocietyId(_context, "Norm's funhouse"),
//                Queries.GetRoomId(_context, "430", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)),
//                new DateTime(2021, 12, 24, 12, 0, 0));

//            _ins.AddBooking(459431, Queries.GetSocietyId(_context, "Norm's funhouse"),
//                Queries.GetRoomId(_context, "Kælderen", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)),
//                new DateTime(2021, 12, 25, 12, 0, 0));

//            _ins.AddBooking(459431, Queries.GetSocietyId(_context, "Norm's funhouse"),
//                Queries.GetRoomId(_context, "430", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)),
//                new DateTime(2021, 12, 26, 12, 0, 0));

//            _ins.AddBooking(854339, Queries.GetSocietyId(_context, "Anonymous"),
//                Queries.GetRoomId(_context, "Fælleren", Queries.GetAddressId(_context, 8200, "Gøteborg Alle", 14)),
//                new DateTime(2021, 12, 24, 12, 0, 0));
//        } }

////        public void loadCodes()
////        {
////            _ins.AddCode(1234,
////                Queries.GetRoomId(_context, "430", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)));
////            _ins.AddCode(4312,
////                Queries.GetRoomId(_context, "430", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)));
////            _ins.AddCode(6969,
////                Queries.GetRoomId(_context, "Kælderen", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)));
////            _ins.AddCode(1627,
////                Queries.GetRoomId(_context, "Fælleren", Queries.GetAddressId(_context, 8200, "Gøteborg Alle", 14)));
////        }

////        public void loadKeys()
////        {
////            _ins.AddKey(
////                Queries.GetRoomId(_context, "Kælderen", Queries.GetAddressId(_context, 8200, "Finlandsgade", 22)),
////                _ins.AddAddress(8000, "Bødker Balles Gård", 17));
////            _ins.AddKey(
////                Queries.GetRoomId(_context, "Fælleren", Queries.GetAddressId(_context, 8200, "Gøteborg Alle", 14)),
////                _ins.AddAddress(7400, "Hos Mathias's forældre", 404));
////        }
////    }
////}
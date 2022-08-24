using System;
using System.Collections.Generic;
using System.Text;

namespace ST10083941_S2_ICE1.Classes
{
    class Event
    {
        public Event(int userID, string name, string place, string date, string time, int numberOfGuests)
        {
            UserID = userID;
            Name = name;
            Place = place;
            Date = date;
            Time = time;
            NumberOfGuests = numberOfGuests;
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int NumberOfGuests { get; set; }
    }
}

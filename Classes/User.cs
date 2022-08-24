using System;
using System.Collections.Generic;
using System.Text;

namespace ST10083941_S2_ICE1.Classes
{
    class User
    {
        public User(int userID, string username, string password)
        {
            UserID = userID;
            Username = username;
            Password = password;
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

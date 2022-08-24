using System;
using System.Collections.Generic;
using System.Text;

namespace ST10083941_S2_ICE1.Classes
{
    class Person
    {
        public Person(int userID, string fullName, string gender, int age)
        {
            UserID = userID;
            FullName = fullName;
            Gender = gender;
            Age = age;
        }

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}

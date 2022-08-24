using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ST10083941_S2_ICE1.Classes;
using System.IO;
using System.Windows.Shapes;

namespace ST10083941_S2_ICE1
{
    /// <summary>
    /// Interaction logic for MyEvents.xaml
    /// </summary>
    public partial class MyEvents : Window
    {
        public  int UserID { get; set; }
        public MyEvents(int userID)
        {
            InitializeComponent();
            UserID = userID;
            StreamReader srEvents = new StreamReader(".//Events.txt", true);
            List<Event> lstEvents = new List<Event>();
            string line = srEvents.ReadLine();
            while (line != null)
            {
                string[] events = line.Split(",");
                int eUserID = Convert.ToInt32(events[0]);
                string name = events[1];
                string place = events[2];
                string date = events[3];
                string time = events[4];
                int numberOfGuests = Convert.ToInt32(events[5]);

                Event myEvent = new Event(eUserID, name, place, date,time, numberOfGuests);
                lstEvents.Add(myEvent);
                line = srEvents.ReadLine();
            }

            var lstMyEvents = lstEvents.FindAll(e => e.UserID == UserID);
            dgMyEvents.ItemsSource = lstMyEvents;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

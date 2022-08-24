using ST10083941_S2_ICE1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10083941_S2_ICE1
{
    /// <summary>
    /// Interaction logic for AllEvents.xaml
    /// </summary>
    public partial class AllEvents : Window
    {
        public AllEvents()
        {
            InitializeComponent();
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

                Event myEvent = new Event(eUserID, name, place, date, time, numberOfGuests);
                lstEvents.Add(myEvent);
                line = srEvents.ReadLine();
            }

            dgAllEvents.ItemsSource = lstEvents;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

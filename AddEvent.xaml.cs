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
using System.Windows.Shapes;
using System.IO;
using ST10083941_S2_ICE1.Classes;

namespace ST10083941_S2_ICE1
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        public int UserID { get; set; }
        public AddEvent(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string name = txbEventName.Text;
            string place = txbPlace.Text;
            string date = dpDate.SelectedDate.Value.Date.ToShortDateString();
            string time = Convert.ToString(tpTime.SelectedTime.Value.TimeOfDay);
            int guests = Convert.ToInt32(nudNumberOfGuests.Value);

            StreamWriter swEvents = new StreamWriter(".//Events.txt", true);
            swEvents.WriteLine($"{UserID},{name},{place},{date},{time},{guests}");
            swEvents.Close();
            MessageBox.Show("Event has been added.");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

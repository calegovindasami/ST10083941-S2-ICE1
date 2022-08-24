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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public int UserID { get; set; }
        public Home()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.ShowDialog();
            this.Show();
            UserID = signUp.UserID;
            MessageBox.Show(UserID.ToString());
            DisplayUserDetails();
        }

        public void DisplayUserDetails()
        {
            pnlNotRegistered.Visibility = Visibility.Collapsed;
            pnlRegistered.Visibility = Visibility.Visible;
            StreamReader srPerson = new StreamReader("People.txt", true);
            List<Person> lstPeople = new List<Person>();

            string line = srPerson.ReadLine();
            while (line != null)
            {
                string[] personDetails = line.Split(",");
                int id = Convert.ToInt32(personDetails[0]);
                string fullName = personDetails[1];
                string gender = personDetails[3];
                int age = Convert.ToInt32(personDetails[2]);
                Person person = new Person(id, fullName, gender, age);
                lstPeople.Add(person);
                line = srPerson.ReadLine();
            }
            srPerson.Close();

            var currentUser = lstPeople.Find(p => p.UserID == UserID);
            txbFullName.Text = currentUser.FullName;
            txbGender.Text = currentUser.Gender;
            txbAge.Text = currentUser.Age.ToString();

        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEvent = new AddEvent(UserID);
            this.Hide();
            addEvent.ShowDialog();
            addEvent.Close();
            this.Show();
        }

        private void btnMyEvents_Click(object sender, RoutedEventArgs e)
        {
            MyEvents myEvents = new MyEvents(UserID);
            this.Hide();
            myEvents.ShowDialog();
            myEvents.Close();
            this.Show();

        }

        private void btnAllEvents_Click(object sender, RoutedEventArgs e)
        {
            AllEvents allEvents = new AllEvents();
            this.Hide();
            allEvents.ShowDialog();
            allEvents.Close();
            this.Show();
        }
    }
}

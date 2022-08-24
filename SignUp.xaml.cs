using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ST10083941_S2_ICE1.Classes;
namespace ST10083941_S2_ICE1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        User user;
        public int UserID{ get; set; }

        public SignUp()
        {
            InitializeComponent();
        }
        
        //Switches login page to sign up page.
        private void btnShowSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.pnlLogin.Visibility = Visibility.Collapsed;
            this.pnlSignUp.Visibility = Visibility.Visible;
        }

        //Signs up user.
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
            pnlSignUp.Visibility = Visibility.Collapsed;
            pnlLogin.Visibility = Visibility.Visible;
        }

        public int AssignUserID()
        {
            StreamReader srUsers = new StreamReader(".//Users.txt");
            string line = srUsers.ReadLine();
            srUsers.Close();
            if (line == null)
            {
                return 0;
            }
            string lastLine = File.ReadAllLines(".//Users.txt").Last();
            string[] user = lastLine.Split(","); 
            int lastUserID = Convert.ToInt32(user[0]);
            int newUserID = lastUserID + 1;
            return newUserID;

        }

        public void CreateUser()
        {
            int userID = AssignUserID();
            string username = txbUsername.Text;
            string password = txbPassword.Password;

            user = new User(userID, username, password);
            StreamWriter swUsers = new StreamWriter(".//Users.txt", true);
            swUsers.WriteLine($"{user.UserID},{user.Username},{user.Password}");
            swUsers.Close();
            CreatePerson(userID);
        }

        public void CreatePerson(int userID)
        {
            string fullName = txbFullName.Text;
            int age = DateTime.Now.Year - dateDOB.SelectedDate.Value.Year;
            string gender = cmbGender.Text;
            StreamWriter swPeople = new StreamWriter(".//People.txt", true);
            swPeople.WriteLine($"{userID},{fullName},{age},{gender}");
            swPeople.Close();
        }

        public void Login()
        {
            StreamReader srUser = new StreamReader(".//Users.txt", true);
            string line = srUser.ReadLine();
            bool bFound = false;
            string username = txbLoginUsername.Text;
            string password = txbLoginPassword.Password;
            while (line != null)
            {
                string[] userDetails = line.Split(",");
                if (username.ToUpper() == userDetails[1].ToUpper())
                {
                    if (password == userDetails[2])
                    {
                        bFound = true;
                        UserID = Convert.ToInt32(userDetails[0]);
                        line = null;
                    }
                }
                line = srUser.ReadLine();
            }
            if (bFound)
            {
                srUser.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("User doesn't exist.");
            }
        }

        public int GetUserID()
        {
            return user.UserID;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
    }
}

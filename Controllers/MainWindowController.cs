/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Logic for collecting and sorting the data according to what is needed
 *                      for the main window
 *      Known Bugs:     None
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace MyFriendTracker
{
    class MainWindowController
    {
        //returns a list of friends that contains the search value
        public static List<Friend> FindFriend(string friendName)
        {
            //read the csv file and put all of them into a list
            CsvHandler readCsv = new CsvHandler();
            List<Friend> friends = new List<Friend>();
            friends = readCsv.ReadCsv();

            //search through list and return another list of friends using the search data
            List<Friend> search = new List<Friend>();
            foreach (Friend friend in friends)
            { 
                //ToUpper is used so capitalization isnt an issue when searching
                if (friend.Name.ToUpper().Contains(friendName))
                {
                    search.Add(friend);
                    Debug.WriteLine(friend.Name);
                }
            }
            //return the list to be displayed
            return search;
        }

        //checks to see if a friends exists in the database
        public static bool CheckIfExists(List<Friend> friends, string name)
        {
            bool check = false;
            //looks through the list given to see if the name given exists
            foreach (Friend friend in friends)
            {
                //Makes both strings capitalized and compares them
                if (friend.Name.ToUpper() == name.ToUpper())
                {
                    check = true;
                }
            }
            return check;
        }

        //adds a new friend to the database
        public static Friend AddNewFriend(Friend friend)
        {
            //first do a date check to see if it is valid
            if (DateCheck(friend.BirthDay, friend.BirthMonth))
            {
                CsvHandler addNewFriend = new CsvHandler();
                addNewFriend.AppendCsv(friend);
                return friend;
            }
            else
            {
                //show a message if the friend try to be edited does not exist
                MessageBox.Show("The Birthday you have entered is invalid, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        //creates a list of all the friends in the database
        public static List<Friend> ShowAllFriends()
        {
            //create a new csv handler object
            CsvHandler getFriends = new CsvHandler();

            //get all the data from the csv and put it in the friends list
            List<Friend> friends = getFriends.ReadCsv();
            
            return friends;
        }

        //returns a list of friends in the given month
        public static List<Friend> FriendsInMonth(int month)
        {
            //read the csv file and put all friends into the list
            CsvHandler readCsv = new CsvHandler();
            List<Friend> friends = new List<Friend>();
            friends = readCsv.ReadCsv();

            //search through the friends and look at the month of their birthday and return a list
            List<Friend> birthdaysInMonth = new List<Friend>();
            foreach (Friend friend in friends)
            {
                if (friend.BirthMonth == month)
                {
                    birthdaysInMonth.Add(friend);
                }
            }
            return birthdaysInMonth;
        }

        //updates the current list of friends and then updates the database
        public static List<Friend> EditFriend(List<Friend> friends, Friend friend)
        {
            //first do a date check to see if it is valid
            if (DateCheck(friend.BirthDay, friend.BirthMonth))
            {
                //Get all the data from the text boxes and update the list
                foreach (Friend f in friends)
                {
                    //ToUpper is used so capitalization isn't an isse when comparing
                    if (f.Name.ToUpper() == friend.Name.ToUpper())
                    {
                        f.Name = friend.Name;
                        f.Likes = friend.Likes;
                        f.Dislikes = friend.Dislikes;
                        f.BirthDay = friend.BirthDay;
                        f.BirthMonth = friend.BirthMonth;

                        //update the csv file
                        CsvHandler write = new CsvHandler();
                        write.AlterCsv(friends);
                        break;
                    }
                }
            }
            else
            {
                //show a message if the friend try to be edited does not exist
                MessageBox.Show("The Birthday you have entered is invalid, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return friends;
        }

        //deletes the friend from the database
        public static List<Friend> DeleteFriend(List<Friend> friends, string name)
        {
            //Get all the data from the text boxes and update the list
            foreach (Friend f in friends)
            {
                if (f.Name == name)
                {
                    //remove the friend from the list
                    friends.Remove(f);

                    //update the csv file using the updated list
                    CsvHandler write = new CsvHandler();
                    write.AlterCsv(friends);

                    //break out of the for loop because the friend has been deleted
                    break;
                }
            }
            return friends;
        }

        //checks the date entered to make sure that it is valid
        private static bool DateCheck(int day, int month)
        {
            //create a date string for parsing
            string birthday = DateTime.Now.Year +"/" + month.ToString() + "/" + day.ToString();

            DateTime date;

            //this only returns true is someones birthday is on the 29th Feb
            if (day == 29 && month == 2)
            {
                return true;
            }
            else if (!DateTime.TryParse(birthday, out date))
            {
                //parse to the date to make sure it is valid
                return false;
            }
            else
            {
                //else the date is valid
                return true;
            }
        }
    }
}

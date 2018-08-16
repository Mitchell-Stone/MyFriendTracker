/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Logic for collecting and sorting the data according to what is needed to be done
 *                      for the main window
 *      Known Bugs:     None
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MyFriendTracker
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling main windows. </summary>
    ///
    /// <remarks>   , 16/08/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class MainWindowController
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Searches for the first friend. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friendName">   Name of the friend. </param>
        ///
        /// <returns>   The found friend. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
                if (friend.Name.ToUpper().Contains(friendName.ToUpper()))
                {
                    search.Add(friend);
                    Debug.WriteLine(friend.Name);
                }
            }
            //return the list to be displayed
            return search;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if exists. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friends">  The friends. </param>
        /// <param name="name">     The name. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a new friend. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friend">   The friend. </param>
        ///
        /// <returns>   A Friend. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows all friends. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <returns>   A List&lt;Friend&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<Friend> ShowAllFriends()
        {
            //create a new csv handler object
            CsvHandler getFriends = new CsvHandler();

            //get all the data from the csv and put it in the friends list
            List<Friend> friends = getFriends.ReadCsv();
            
            return friends;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Friends in month. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="month">    The month. </param>
        ///
        /// <returns>   A List&lt;Friend&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Edit friend. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friends">      The friends. </param>
        /// <param name="friend">       The friend. </param>
        /// <param name="comparison">   The comparison. </param>
        ///
        /// <returns>   A List&lt;Friend&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<Friend> EditFriend(List<Friend> friends, Friend friend, string comparison)
        {
            //first do a date check to see if it is valid
            if (DateCheck(friend.BirthDay, friend.BirthMonth))
            {
                foreach (Friend f in friends)
                {
                    //ToUpper is used so capitalization isn't an issue when comparing
                    if (f.Name.ToUpper() == comparison.ToUpper())
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the friend. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friends">  The friends. </param>
        /// <param name="name">     The name. </param>
        ///
        /// <returns>   A List&lt;Friend&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Date check. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="day">      The day. </param>
        /// <param name="month">    The month. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Binary search. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friends">      The friends. </param>
        /// <param name="searchValue">  The search value. </param>
        ///
        /// <returns>   A List&lt;Friend&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Friend> BinarySearch(List<Friend> friends, string searchValue)
        {
            List<Friend> searchList = new List<Friend>();
            //should only conduct a binary search on an ordered list for it to be correct
            //convert list to array
            Friend[] sortedArray = friends.OrderBy(o => o.Name).ToArray();

            /*
             * conduct a binary search on the sorted array by creating a new friend object that contains only the name
             * using the data entered into the binary search textbox 
             */
            int index = Array.BinarySearch(sortedArray, new Friend() { Name = searchValue });

            //if the friend exists, add them to the list
            if (index < 0)
            {
                //if index is less that zero, this means that the friend does not exist
                searchList = null;
            }
            else
            {
                //create a new friend object using the object found at the index of the sorted list
                Friend friend = new Friend()
                {
                    Name = sortedArray[index].Name,
                    Likes = sortedArray[index].Likes,
                    Dislikes = sortedArray[index].Dislikes,
                    BirthDay = sortedArray[index].BirthDay,
                    BirthMonth = sortedArray[index].BirthMonth
                };
                //add the friend to the list
                searchList.Add(friend);
            }
            return searchList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sort friends. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <returns>   The sorted friends. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<Friend> SortFriends(List<Friend> friends)
        {
            return friends.OrderBy(o => o.BirthMonth).ToList();
        }

        public static void DateInputCheck(string check)
        {
            int number;
            bool isNumber = Int32.TryParse(check, out number);

        }
    }
}

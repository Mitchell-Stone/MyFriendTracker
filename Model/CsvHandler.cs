﻿/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Logic for reading, writing and appending to the csv file which
 *                      is the database for storing the friends information
 *      Known Bugs:     None
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyFriendTracker
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A CSV handler. </summary>
    ///
    /// <remarks>   , 16/08/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class CsvHandler
    {
        /// <summary>   File location </summary>
        private string directory = @"C:\MyFriends\";
        /// <summary>   Name of the CSV. </summary>
        private string csvName = "MyFriendData.csv";
   
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads the CSV. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <returns>   The CSV. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Friend> ReadCsv()
        {
            List<Friend> allFriends = new List<Friend>();
            string fullPath = directory + csvName;

            //if the file does not exist, create csv, add an example friend and return the list
            if (!File.Exists(fullPath))
            {
                //create the directory
                Directory.CreateDirectory(directory);

                //create the default friend object
                Friend friend = new Friend()
                {
                    Name = "Mitchell",
                    Likes = "Cars",
                    Dislikes = "Ornaments",
                    BirthDay = 23,
                    BirthMonth = 3
                };

                //add default friend to the list
                allFriends.Add(friend);

                //add default friend to the csv so there is something to read
                AppendCsv(friend);
            }
            else
            {
                //read all the friends in the csv file
                using (var reader = new StreamReader(fullPath))
                {
                    //create and empty string for the each line of the csv to be saved to
                    string line = string.Empty;

                    //loop over each line in the csv and add them to the friends list
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        Friend friend = new Friend
                        {
                            Name = values[0],
                            Likes = values[1],
                            Dislikes = values[2],
                            BirthDay = Convert.ToInt32(values[3]),
                            BirthMonth = Convert.ToInt32(values[4])
                        };
                        allFriends.Add(friend);
                    }
                    //close the connection to the file
                    reader.Close();
                }
            }

            //sort the list by month ascending
            allFriends = allFriends.OrderBy(o => o.BirthMonth).ToList();
            //return a list of all friends
            return allFriends;
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Alter CSV. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="editFriend">   The edit friend. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AlterCsv(List<Friend> editFriend)
        {
            string fullPath = directory + csvName;
            //open a write stream to the csv file
            using (var writer = new StreamWriter(fullPath))
            {
                //loop over the edited list and re-write each friend to the csv
                foreach (Friend friend in editFriend)
                {
                    writer.WriteLine(friend.Name + "," + friend.Likes + "," + friend.Dislikes + "," +
                        friend.BirthDay + "," + friend.BirthMonth);
                }
                //Close the connection to the file
                writer.Close();
            }
        }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Appends a CSV. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="newFriend">    The new friend. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AppendCsv(Friend newFriend)
        {
            string fullPath = directory + csvName;
            //Open a write stream to the csv file - true = append on a new line
            using (StreamWriter writer = File.AppendText(fullPath))
            {
                //create the string to be written to the csv file
                string data = newFriend.Name + "," + newFriend.Likes + "," + newFriend.Dislikes 
                    + "," + newFriend.BirthDay + "," + newFriend.BirthMonth;
                //append the data to the file
                writer.WriteLine(data);

                //close the connection to the file
                writer.Close();
            }
        }
    }
}

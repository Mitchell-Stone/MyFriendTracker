/*
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

namespace MyFriendTracker
{
    class CsvHandler
    {
        private string friendsCsv = @"C:\Users\0111005906\Desktop\C# Assessments\MyFriendTracker\friends.csv";

        public List<Friend> ReadCsv()
        {
            List<Friend> allFriends = new List<Friend>();
            //read all the friends in the csv file
            using (var reader = new StreamReader(friendsCsv))
            {
                string line = string.Empty;

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
            //return a list of all friends
            return allFriends;
        }

        public void AlterCsv(List<Friend> editFriend)
        {
            //read the csv file
            using (var writer = new StreamWriter(friendsCsv))
            {
                foreach (Friend friend in editFriend)
                {
                    writer.WriteLine(friend.Name + "," + friend.Likes + "," + friend.Dislikes + "," +
                        friend.BirthDay + "," + friend.BirthMonth);
                }
                //Close the connection to the file
                writer.Close();
            }
            //write data to the csv file altering what already exists
        }

        public void AppendCsv(Friend newFriend)
        {
            //Open a write stream to the csv file - true = append on a new line
            using (StreamWriter writer = File.AppendText(friendsCsv))
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

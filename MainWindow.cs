﻿
/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Logic for displaying the data in the main window
 *      Known Bugs:     None
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MyFriendTracker
{
    public partial class MainWindow : Form
    {
        //Create a list to store all friends and to be the datasource for the datagridview
        List<Friend> friends = new List<Friend>();

        //A list used for the scrolling buttons
        List<Friend> scrollList;

        //A temporary list used to store friends
        List<Friend> tempList;

        //Object to store a friend properties value
        Friend friend;

        //index counter
        int index = 0;

        //Dictionary for months and ints releated to these months e.g. March = 3
        Dictionary<string, int> Months = new Dictionary<string, int>
        {
            { "Janurary", 1 }, { "Feburary", 2 }, { "March", 3 }, { "April", 4 }, { "May", 5 }, { "June", 6 },
            { "July", 7 }, { "August", 8 }, {"September", 9 }, {"October", 10 }, {"November", 11 }, {"December", 12 }
        };

        public MainWindow()
        {
            InitializeComponent();

            friends = MainWindowController.ShowAllFriends();

            //set the data source for the datagridview so it knows what data to show
            dgv_friends.DataSource = friends;
            //resize the columns to fit
            dgv_friends.AutoResizeColumns();
            dgv_friends.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //set the cells to read only
            dgv_friends.ReadOnly = true;
            //sets the selection mode so the entire row is selected, not just the cell
            dgv_friends.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //set the values to be shown in the dropdown for the month selector
            List<string> months = new List<string>(Months.Keys);
            cb_monthSelector.DataSource = months;
        }

        private void btn_firstRecord_Click(object sender, EventArgs e)
        {
            //go to the very first record
            index = 0;
            //create a new scroll list for the data grid view datasource
            scrollList = new List<Friend>();
            //add the friend to the scroll list
            scrollList.Add(friends.First());
            //update the datasource to show the changes
            dgv_friends.DataSource = scrollList;
        }

        private void btn_previousRecord_Click(object sender, EventArgs e)
        {
            //move to the previous record
            //create a new scroll list for the data grid view datasource
            scrollList = new List<Friend>();
            if (index <= 0)
            {
                //if the index is 0 or less than 0
                index = 0;
                //add a friend from the given index
                scrollList.Add(friends.First());
            }
            else
            {
                //else subtract 1
                index -= 1;
                //add a friend from the given index
                scrollList.Add(friends[index]);
            }   
            //update the datasource to show the changes
            dgv_friends.DataSource = scrollList;
        }

        private void btn_nextRecord_Click(object sender, EventArgs e)
        {
            //move to the next record
            //create a new scroll list for the data grid view datasource
            scrollList = new List<Friend>();
            if (index >= friends.Count() - 1)
            {
                //if at the final index only show the last entry
                index = friends.Count() - 1;
                scrollList.Add(friends.Last());
            }
            else
            {
                //add the index by one
                index += 1;
                //add a friend from the given index
                scrollList.Add(friends[index]);
            }
            //update the datasource to show the changes
            dgv_friends.DataSource = scrollList;
        }

        private void btn_lastRecord_Click(object sender, EventArgs e)
        {
            //Show the very last record
            index = friends.Count() - 1;
            //create a new scroll list for the data grid view datasource
            scrollList = new List<Friend>();
            //add the friend to the list
            scrollList.Add(friends.Last());
            //update the datasource to show the changes
            dgv_friends.DataSource = scrollList;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //close the current window
            this.Close();
        }

        private void btn_newFriend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_friendName.Text) || string.IsNullOrWhiteSpace(tb_friendLikes.Text) ||
                string.IsNullOrWhiteSpace(tb_friendDislikes.Text) || string.IsNullOrWhiteSpace(tb_birthMonth.Text) ||
                string.IsNullOrWhiteSpace(tb_birthDay.Text))
            {
                //if any of the textboxes are empty, display a message
                MessageBox.Show("You have not entered all the relevant details, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MainWindowController.CheckIfExists(friends, tb_friendName.Text))
            {
                //if someone with the name already exists, display message
                MessageBox.Show("A friend with that name already exists, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //add the friend to the database
                Friend newFriend = MainWindowController.AddNewFriend(CreateFriendObject());

                //update the current list and update the datasource to show the change
                if (newFriend != null)
                {
                    friends.Add(newFriend);
                    UpdateDatasource();
                }  
            }  
        }

        private void btn_saveFriend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_friendName.Text))
            {
                //if no friend is selected, display message
                MessageBox.Show("You have not selected a friend, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MainWindowController.CheckIfExists(friends, tb_friendName.Text) == false)
            {
                //checks if the person to be edited exists, if not display message
                MessageBox.Show("There is no friend with the name " + tb_friendName.Text + " to edit, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //create a new friend object because all fields can be changed
                friend = CreateFriendObject();

                //update the database and return an updated list
                friends = MainWindowController.EditFriend(friends, friend);

                //update the datasourse to show the changes
                UpdateDatasource();
            }

        }

        private void btn_deleteFriend_Click(object sender, EventArgs e)
        {
            //delete the selected frind from the database and display a message
            MainWindowController.DeleteFriend(friends, tb_friendName.Text);
            lbl_message.Text = String.Format("{0} has been deleted!", tb_friendName.Text);

            //clear the text boxes of friends data
            ClearTextBoxes();

            //update the datasourse to show the changes
            UpdateDatasource();
        }

        private void btn_findFriend_Click(object sender, EventArgs e)
        {
            //Get the name entered and display a message
            friends = MainWindowController.FindFriend(tb_friendSearch.Text.ToUpper());
            lbl_message.Text = String.Format("This is the details for {0}", tb_friendSearch.Text);

            //update the datasourse to show the changes
            UpdateDatasource();
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            //updates the friends list to contain all friends stored in the csv
            friends = MainWindowController.ShowAllFriends();

            //update the datasourse to show the changes
            UpdateDatasource();
        }

        private void btn_binarySearch_Click(object sender, EventArgs e)
        {

        }

        private void btn_birthdayInMonthOf_Click(object sender, EventArgs e)
        {
            //get the month entered, search for all birthdays in that month and display a message
            tempList = MainWindowController.FriendsInMonth(Months[cb_monthSelector.Text]);
            lbl_message.Text = String.Format("All birthdays in the month of {0}", cb_monthSelector.Text);

            //update the datasourse to show the changes
            dgv_friends.DataSource = tempList;
            
        }

        private void dgv_friends_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_friends.SelectedRows)
            {
                //creates a friend object when a row is selected in the datagridview
                friend = row.DataBoundItem as Friend;

                //update the text boxes to show the selected friends details
                tb_friendName.Text = friend.Name;
                tb_friendLikes.Text = friend.Likes;
                tb_friendDislikes.Text = friend.Dislikes;
                tb_birthDay.Text = friend.BirthDay.ToString();
                tb_birthMonth.Text = friend.BirthMonth.ToString();

                //get the index of the currently selected friend
                index = friends.FindIndex(i => i.Name == friend.Name);
                Debug.WriteLine(index.ToString());

                //debug to check if an object is selected
                Debug.WriteLine(friend.Name);
            } 
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //only clears the text boxes if a row in the datagridview is selected
            if (dgv_friends.SelectedRows.Count > 0)
            {
                dgv_friends.ClearSelection();
                ClearTextBoxes();
            }  
        }

        private void ClearTextBoxes()
        {
            //clear all relevant text boxes
            tb_friendName.Clear();
            tb_friendLikes.Clear();
            tb_friendDislikes.Clear();
            tb_birthDay.Clear();
            tb_birthMonth.Clear();
        }

        private void UpdateDatasource()
        {
            dgv_friends.DataSource = null;
            dgv_friends.DataSource = friends;
        }

        private Friend CreateFriendObject()
        {
            //create and return a new friend object using the data in the text boxes
            friend = new Friend()
            {
                Name = tb_friendName.Text,
                Likes = tb_friendLikes.Text,
                Dislikes = tb_friendDislikes.Text,
                BirthDay = Convert.ToInt32(tb_birthDay.Text),
                BirthMonth = Convert.ToInt32(tb_birthMonth.Text)
            };
            return friend;
        }
    }
}

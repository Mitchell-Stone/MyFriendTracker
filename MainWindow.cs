/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Logic for displaying the data in the main window
 *      Known Bugs:     None
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MyFriendTracker
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The application's main form. </summary>
    ///
    /// <remarks>   , 16/08/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class MainWindow : Form
    {
        /*
         * This class is the View for the My Friend Tracker application. All logic in regards to the use of the window
         * functions happens here
         */

        //Create a list to store all friends and to be the datasource for the datagridview
        /// <summary>   The friends. </summary>
        List<Friend> friends = new List<Friend>();

        //Object to store a friend properties value
        /// <summary>   The friend. </summary>
        Friend friend;

        //index counter
        /// <summary>   Zero-based index of the. </summary>
        int index = 0;

        //Dictionary for months and ints releated to these months e.g. March = 3
        /// <summary>   The months. </summary>
        Dictionary<string, int> Months = new Dictionary<string, int>
        {
            { "Janurary", 1 }, { "Feburary", 2 }, { "March", 3 }, { "April", 4 }, { "May", 5 }, { "June", 6 },
            { "July", 7 }, { "August", 8 }, {"September", 9 }, {"October", 10 }, {"November", 11 }, {"December", 12 }
        };

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainWindow()
        {
            InitializeComponent();

            //collect all the friends and put them into a list
            friends = MainWindowController.ShowAllFriends();
                        //set the data source for the datagridview so it knows what data to show
            dgv_friends.DataSource = friends;
            //resize the columns to fit
            dgv_friends.AutoResizeColumns();
            //get the columns to fit the width of the data grid view
            dgv_friends.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //set the cells to read only
            dgv_friends.ReadOnly = true;
            //sets the selection mode so the entire row is selected, not just the cell
            dgv_friends.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //set the values to be shown in the dropdown for the month selector
            List<string> months = new List<string>(Months.Keys);
            cb_monthSelector.DataSource = months;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_firstRecord for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_firstRecord_Click(object sender, EventArgs e)
        {
            DeselectRow(index);
            //select the very first record
            index = 0;
            SelectRow(index);
            PopulateTextBoxes(friends[index]);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_previousRecord for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_previousRecord_Click(object sender, EventArgs e)
        {
            //deselect the current row
            DeselectRow(index);
            //remove 1 from the index to get previous record
            index -= 1;
            //make sure index does not go out of bounds
            if (index <= 0)
            {
                index = 0;
            }
            //get the index of the new record
            index = friends.FindIndex(o => o.Name == friends[index].Name);
            //select that row in the datagridview
            SelectRow(index);
            //populate the text boxes to show the new selection data
            PopulateTextBoxes(friends[index]);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_nextRecord for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_nextRecord_Click(object sender, EventArgs e)
        {
            //deselect the current row
            DeselectRow(index);
            //add one to the index to get the next record
            index += 1;
            //make sure that the index does not go out of bounds
            if (index >= friends.Count() - 1)
            {
                index = friends.Count() - 1;
            }
            //get the index for the next record
            index = friends.FindIndex(o => o.Name == friends[index].Name);
            //select that row in the datagridview
            SelectRow(index);
            //update the text boxes to show the new data
            PopulateTextBoxes(friends[index]);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_lastRecord for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_lastRecord_Click(object sender, EventArgs e)
        {
            //deselect the current row
            DeselectRow(index);
            //Select the very last record
            index = friends.Count() - 1;
            SelectRow(index);
            PopulateTextBoxes(friends[index]);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_exit for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //close the current window
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_newFriend for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_newFriend_Click(object sender, EventArgs e)
        {
            try
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
                    MessageBox.Show(string.Format("A friend with the name {0} already exists, please try again", tb_friendName.Text), "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //add the friend to the database
                    Friend newFriend = MainWindowController.AddNewFriend(CreateFriendObject());

                    //update label to show that someone has been added
                    lbl_message.Text = String.Format("{0} has been added to your friends list", newFriend.Name);

                    //update the current list and update the datasource to show the change
                    if (newFriend != null)
                    {
                        friends.Add(newFriend);
                        //sort the list by month ascending and update the data source
                        friends = MainWindowController.SortFriends(friends);
                        UpdateDatasource(friends);

                        //select the new friend
                        SelectRow(friends.FindIndex(x => x.Name == newFriend.Name));
                    }
                    ClearTextBoxes();
                }

            }
            catch (Exception ex)
            {
                //checks if there is data in the search box, if not display message
                MessageBox.Show("You have entered an incorrect date, please try again.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_birthDay.Clear();
                tb_birthMonth.Clear();
                Debug.WriteLine(ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_saveFriend for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_saveFriend_Click(object sender, EventArgs e)
        {
            string friendName = tb_friendName.Text;

            if (string.IsNullOrWhiteSpace(friendName))
            {
                //if no friend is selected, display message
                MessageBox.Show("You have not selected a friend, please try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Friend editFriend = friends[index];
                editFriend.Name = friendName;
                editFriend.Likes = tb_friendLikes.Text;
                editFriend.Dislikes = tb_friendDislikes.Text;
                editFriend.BirthDay = Convert.ToInt32(tb_birthDay.Text);
                editFriend.BirthMonth = Convert.ToInt32(tb_birthMonth.Text);

                //update the database and return an updated list
                friends = MainWindowController.EditFriend(friends, editFriend, friendName);

                //update the datasourse to show the changes
                UpdateDatasource(MainWindowController.SortFriends(friends));

                SelectRow(index);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_deleteFriend for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_deleteFriend_Click(object sender, EventArgs e)
        {
            //delete the selected frind from the database and display a message
            MainWindowController.DeleteFriend(friends, tb_friendName.Text);
            lbl_message.Text = String.Format("{0} has been deleted!", tb_friendName.Text);

            //clear the text boxes of friends data
            ClearTextBoxes();

            //update the datasourse to show the changes
            UpdateDatasource(friends);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_findFriend for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_findFriend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_friendSearch.Text))
            {
                //checks if there is data in the search box, if not display message
                MessageBox.Show("There is no data entered in the search box, please try again.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Get the name entered and display a message
                List<Friend> searchList  = MainWindowController.FindFriend(tb_friendSearch.Text);

                //only 1 friend is found
                if (searchList.Count == 1)
                {
                    lbl_message.Text = String.Format("There is only one friend with that contains {0}.", tb_friendSearch.Text);

                    //populate the text box with the complete searched value
                    PopulateTextBoxes(searchList[0]);
                    tb_friendSearch.Clear();

                    //get the index of where the friend is so it knows where to move the selection
                    int index = friends.FindIndex(o => o.Name == searchList[0].Name);

                    //update the datasource to the friends list
                    UpdateDatasource(friends);

                    //remove the currently selected rom and change it to the location of where the friend is in the view
                    dgv_friends.CurrentRow.Selected = false;
                    dgv_friends.Rows[index].Selected = true;
                }
                else
                {
                    lbl_message.Text = String.Format("Displaying all friends with {0} in their name.", tb_friendSearch.Text);

                    //clear all the text boxes
                    ClearTextBoxes();

                    //update the datasourse to show the changes
                    UpdateDatasource(searchList);
                }               
            }         
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_showAll for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            //updates the friends list to contain all friends stored in the csv
            friends = MainWindowController.ShowAllFriends();

            //clear the label
            lbl_message.Text = "";

            //clear all the text boxes
            ClearTextBoxes();
            tb_binarySearch.Clear();

            //update the datasourse to show the changes
            UpdateDatasource(friends);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_binarySearch for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_binarySearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_binarySearch.Text))
            {
                //checks if there is data in the search box, if not display message
                MessageBox.Show("There is no data entered in the Binary Search box, please try again.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MainWindowController search = new MainWindowController();
               
                //add the friend to the temp list and update the datasource
                List<Friend> binaryList = search.BinarySearch(friends, tb_binarySearch.Text);
                UpdateDatasource(binaryList);

                //populate the text fields with the friend data from the first index
                //This will always be true because there will only ever be a single freind in the list
                if (binaryList != null)
                {
                    //display the result
                    PopulateTextBoxes(binaryList[0]);
                    lbl_message.Text = string.Format("All details are being shown for {0}", binaryList[0].Name);
                }
                else
                {
                    //detail that the search returned nothing
                    lbl_message.Text = string.Format("Details for {0} do not exist", tb_binarySearch.Text);                  
                }   
            }   
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btn_birthdayInMonthOf for click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_birthdayInMonthOf_Click(object sender, EventArgs e)
        {
            //get the month entered, search for all birthdays in that month and display a message
            friends = MainWindowController.FriendsInMonth(Months[cb_monthSelector.Text]);
            lbl_message.Text = String.Format("All birthdays in the month of {0}", cb_monthSelector.Text);

            index = 0;
            ClearTextBoxes();
            //update the datasourse to show the changes
            UpdateDatasource(friends);
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by dgv_friends for cell click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgv_friends_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_friends.SelectedRows)
            {
                //create a new friend from the selected row
                friend = row.DataBoundItem as Friend;

                //update the text boxes to show the selected friends details
                PopulateTextBoxes(friend);

                //get the index of the currently selected friend
                index = friends.FindIndex(i => i.Name == friend.Name);
            } 
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Form1 for mouse click events. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //only clears the text boxes if a row in the datagridview is selected
            if (dgv_friends.SelectedRows.Count > 0)
            {
                dgv_friends.ClearSelection();
                ClearTextBoxes();
            }  
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clears the text boxes. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ClearTextBoxes()
        {
            //clear all relevant text boxes
            tb_friendName.Clear();
            tb_friendLikes.Clear();
            tb_friendDislikes.Clear();
            tb_birthDay.Clear();
            tb_birthMonth.Clear();
            tb_friendSearch.Clear();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the datasource described by list. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="list"> The list. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UpdateDatasource(List<Friend> list)
        {
            //set the data source to null
            dgv_friends.DataSource = null;

            //set the data source to the new sorted list to update the datagridview
            dgv_friends.DataSource = MainWindowController.SortFriends(list);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates friend object. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <returns>   The new friend object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Friend CreateFriendObject()
        {
            //create and return a new friend object using the data in the text boxes
            Friend newFriend = new Friend()
            {
                Name = tb_friendName.Text,
                Likes = tb_friendLikes.Text,
                Dislikes = tb_friendDislikes.Text,
                BirthDay = Convert.ToInt32(tb_birthDay.Text),
                BirthMonth = Convert.ToInt32(tb_birthMonth.Text)
            };
            return newFriend;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Populates a text boxes. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="friend">   The friend. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PopulateTextBoxes(Friend friend)
        {
            //update the text boxes to show the selected friends details
            tb_friendName.Text = friend.Name;
            tb_friendLikes.Text = friend.Likes;
            tb_friendDislikes.Text = friend.Dislikes;
            tb_birthDay.Text = friend.BirthDay.ToString();
            tb_birthMonth.Text = friend.BirthMonth.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deselect row. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="oldIndex"> The old index. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void DeselectRow(int oldIndex)
        {
            try
            {
                dgv_friends.Rows[oldIndex].Selected = false;
                dgv_friends.CurrentCell = null;
            }
            catch (ArgumentOutOfRangeException)
            {

                dgv_friends.Rows[0].Selected = false;
                dgv_friends.CurrentCell = null;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Select row. </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="newIndex"> The new index. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SelectRow(int newIndex)
        {
            try { 
                dgv_friends.Rows[newIndex].Selected = true;
                dgv_friends.CurrentCell = dgv_friends.Rows[newIndex].Cells[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                dgv_friends.Rows[0].Selected = true;
                dgv_friends.CurrentCell = dgv_friends.Rows[0].Cells[0];
            }
        }
    }
}

namespace MyFriendTracker
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_findFriend = new System.Windows.Forms.Button();
            this.tb_friendSearch = new System.Windows.Forms.TextBox();
            this.tb_friendName = new System.Windows.Forms.TextBox();
            this.tb_birthMonth = new System.Windows.Forms.TextBox();
            this.tb_birthDay = new System.Windows.Forms.TextBox();
            this.tb_friendDislikes = new System.Windows.Forms.TextBox();
            this.tb_friendLikes = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_birthdayInMonthOf = new System.Windows.Forms.Button();
            this.btn_binarySearch = new System.Windows.Forms.Button();
            this.btn_deleteFriend = new System.Windows.Forms.Button();
            this.btn_editFriend = new System.Windows.Forms.Button();
            this.btn_newFriend = new System.Windows.Forms.Button();
            this.cb_monthSelector = new System.Windows.Forms.ComboBox();
            this.btn_firstRecord = new System.Windows.Forms.Button();
            this.btn_lastRecord = new System.Windows.Forms.Button();
            this.btn_nextRecord = new System.Windows.Forms.Button();
            this.btn_previousRecord = new System.Windows.Forms.Button();
            this.dgv_friends = new System.Windows.Forms.DataGridView();
            this.lbl_message = new System.Windows.Forms.Label();
            this.btn_showAll = new System.Windows.Forms.Button();
            this.tb_binarySearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(75, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Birthday Tracker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(441, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Find Friend:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.RoyalBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(42, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Friends Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.RoyalBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(42, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Likes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.RoyalBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(42, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dislikes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.RoyalBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(42, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Birth Day:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.RoyalBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(42, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Birth Month";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.RoyalBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(42, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Birthday List:";
            // 
            // btn_findFriend
            // 
            this.btn_findFriend.Location = new System.Drawing.Point(539, 85);
            this.btn_findFriend.Name = "btn_findFriend";
            this.btn_findFriend.Size = new System.Drawing.Size(147, 23);
            this.btn_findFriend.TabIndex = 11;
            this.btn_findFriend.Text = "Find Friend";
            this.btn_findFriend.UseVisualStyleBackColor = true;
            this.btn_findFriend.Click += new System.EventHandler(this.btn_findFriend_Click);
            // 
            // tb_friendSearch
            // 
            this.tb_friendSearch.Location = new System.Drawing.Point(540, 55);
            this.tb_friendSearch.Name = "tb_friendSearch";
            this.tb_friendSearch.Size = new System.Drawing.Size(146, 20);
            this.tb_friendSearch.TabIndex = 10;
            // 
            // tb_friendName
            // 
            this.tb_friendName.Location = new System.Drawing.Point(180, 138);
            this.tb_friendName.Name = "tb_friendName";
            this.tb_friendName.Size = new System.Drawing.Size(213, 20);
            this.tb_friendName.TabIndex = 1;
            // 
            // tb_birthMonth
            // 
            this.tb_birthMonth.Location = new System.Drawing.Point(180, 264);
            this.tb_birthMonth.Name = "tb_birthMonth";
            this.tb_birthMonth.Size = new System.Drawing.Size(121, 20);
            this.tb_birthMonth.TabIndex = 5;
            // 
            // tb_birthDay
            // 
            this.tb_birthDay.Location = new System.Drawing.Point(180, 233);
            this.tb_birthDay.Name = "tb_birthDay";
            this.tb_birthDay.Size = new System.Drawing.Size(121, 20);
            this.tb_birthDay.TabIndex = 4;
            // 
            // tb_friendDislikes
            // 
            this.tb_friendDislikes.Location = new System.Drawing.Point(180, 202);
            this.tb_friendDislikes.Name = "tb_friendDislikes";
            this.tb_friendDislikes.Size = new System.Drawing.Size(213, 20);
            this.tb_friendDislikes.TabIndex = 3;
            // 
            // tb_friendLikes
            // 
            this.tb_friendLikes.Location = new System.Drawing.Point(180, 171);
            this.tb_friendLikes.Name = "tb_friendLikes";
            this.tb_friendLikes.Size = new System.Drawing.Size(213, 20);
            this.tb_friendLikes.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(540, 514);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(147, 23);
            this.btn_exit.TabIndex = 19;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_birthdayInMonthOf
            // 
            this.btn_birthdayInMonthOf.Location = new System.Drawing.Point(539, 409);
            this.btn_birthdayInMonthOf.Name = "btn_birthdayInMonthOf";
            this.btn_birthdayInMonthOf.Size = new System.Drawing.Size(147, 23);
            this.btn_birthdayInMonthOf.TabIndex = 17;
            this.btn_birthdayInMonthOf.Text = "Birthdays in Month of:";
            this.btn_birthdayInMonthOf.UseVisualStyleBackColor = true;
            this.btn_birthdayInMonthOf.Click += new System.EventHandler(this.btn_birthdayInMonthOf_Click);
            // 
            // btn_binarySearch
            // 
            this.btn_binarySearch.Location = new System.Drawing.Point(539, 380);
            this.btn_binarySearch.Name = "btn_binarySearch";
            this.btn_binarySearch.Size = new System.Drawing.Size(147, 23);
            this.btn_binarySearch.TabIndex = 16;
            this.btn_binarySearch.Text = "Binary Search";
            this.btn_binarySearch.UseVisualStyleBackColor = true;
            this.btn_binarySearch.Click += new System.EventHandler(this.btn_binarySearch_Click);
            // 
            // btn_deleteFriend
            // 
            this.btn_deleteFriend.Location = new System.Drawing.Point(540, 231);
            this.btn_deleteFriend.Name = "btn_deleteFriend";
            this.btn_deleteFriend.Size = new System.Drawing.Size(147, 23);
            this.btn_deleteFriend.TabIndex = 15;
            this.btn_deleteFriend.Text = "Delete Selected Friend";
            this.btn_deleteFriend.UseVisualStyleBackColor = true;
            this.btn_deleteFriend.Click += new System.EventHandler(this.btn_deleteFriend_Click);
            // 
            // btn_editFriend
            // 
            this.btn_editFriend.Location = new System.Drawing.Point(540, 200);
            this.btn_editFriend.Name = "btn_editFriend";
            this.btn_editFriend.Size = new System.Drawing.Size(147, 23);
            this.btn_editFriend.TabIndex = 14;
            this.btn_editFriend.Text = "Save Friend Changes";
            this.btn_editFriend.UseVisualStyleBackColor = true;
            this.btn_editFriend.Click += new System.EventHandler(this.btn_saveFriend_Click);
            // 
            // btn_newFriend
            // 
            this.btn_newFriend.Location = new System.Drawing.Point(540, 167);
            this.btn_newFriend.Name = "btn_newFriend";
            this.btn_newFriend.Size = new System.Drawing.Size(147, 23);
            this.btn_newFriend.TabIndex = 13;
            this.btn_newFriend.Text = "Save New Friend";
            this.btn_newFriend.UseVisualStyleBackColor = true;
            this.btn_newFriend.Click += new System.EventHandler(this.btn_newFriend_Click);
            // 
            // cb_monthSelector
            // 
            this.cb_monthSelector.FormattingEnabled = true;
            this.cb_monthSelector.Location = new System.Drawing.Point(541, 438);
            this.cb_monthSelector.Name = "cb_monthSelector";
            this.cb_monthSelector.Size = new System.Drawing.Size(146, 21);
            this.cb_monthSelector.TabIndex = 18;
            // 
            // btn_firstRecord
            // 
            this.btn_firstRecord.Location = new System.Drawing.Point(46, 295);
            this.btn_firstRecord.Name = "btn_firstRecord";
            this.btn_firstRecord.Size = new System.Drawing.Size(46, 23);
            this.btn_firstRecord.TabIndex = 6;
            this.btn_firstRecord.Text = "|<";
            this.btn_firstRecord.UseVisualStyleBackColor = true;
            this.btn_firstRecord.Click += new System.EventHandler(this.btn_firstRecord_Click);
            // 
            // btn_lastRecord
            // 
            this.btn_lastRecord.Location = new System.Drawing.Point(202, 295);
            this.btn_lastRecord.Name = "btn_lastRecord";
            this.btn_lastRecord.Size = new System.Drawing.Size(46, 23);
            this.btn_lastRecord.TabIndex = 9;
            this.btn_lastRecord.Text = ">|";
            this.btn_lastRecord.UseVisualStyleBackColor = true;
            this.btn_lastRecord.Click += new System.EventHandler(this.btn_lastRecord_Click);
            // 
            // btn_nextRecord
            // 
            this.btn_nextRecord.Location = new System.Drawing.Point(150, 295);
            this.btn_nextRecord.Name = "btn_nextRecord";
            this.btn_nextRecord.Size = new System.Drawing.Size(46, 23);
            this.btn_nextRecord.TabIndex = 8;
            this.btn_nextRecord.Text = ">";
            this.btn_nextRecord.UseVisualStyleBackColor = true;
            this.btn_nextRecord.Click += new System.EventHandler(this.btn_nextRecord_Click);
            // 
            // btn_previousRecord
            // 
            this.btn_previousRecord.Location = new System.Drawing.Point(98, 295);
            this.btn_previousRecord.Name = "btn_previousRecord";
            this.btn_previousRecord.Size = new System.Drawing.Size(46, 23);
            this.btn_previousRecord.TabIndex = 7;
            this.btn_previousRecord.Text = "<";
            this.btn_previousRecord.UseVisualStyleBackColor = true;
            this.btn_previousRecord.Click += new System.EventHandler(this.btn_previousRecord_Click);
            // 
            // dgv_friends
            // 
            this.dgv_friends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_friends.Location = new System.Drawing.Point(44, 366);
            this.dgv_friends.MultiSelect = false;
            this.dgv_friends.Name = "dgv_friends";
            this.dgv_friends.Size = new System.Drawing.Size(460, 214);
            this.dgv_friends.TabIndex = 26;
            this.dgv_friends.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_friends_CellClick);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.Location = new System.Drawing.Point(157, 330);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(0, 20);
            this.lbl_message.TabIndex = 27;
            // 
            // btn_showAll
            // 
            this.btn_showAll.Location = new System.Drawing.Point(539, 114);
            this.btn_showAll.Name = "btn_showAll";
            this.btn_showAll.Size = new System.Drawing.Size(147, 23);
            this.btn_showAll.TabIndex = 12;
            this.btn_showAll.Text = "Show All Friends";
            this.btn_showAll.UseVisualStyleBackColor = true;
            this.btn_showAll.Click += new System.EventHandler(this.btn_showAll_Click);
            // 
            // tb_binarySearch
            // 
            this.tb_binarySearch.Location = new System.Drawing.Point(541, 354);
            this.tb_binarySearch.Name = "tb_binarySearch";
            this.tb_binarySearch.Size = new System.Drawing.Size(145, 20);
            this.tb_binarySearch.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.RoyalBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(537, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "Friends Full Name:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(771, 592);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_binarySearch);
            this.Controls.Add(this.btn_showAll);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.dgv_friends);
            this.Controls.Add(this.btn_previousRecord);
            this.Controls.Add(this.btn_nextRecord);
            this.Controls.Add(this.btn_lastRecord);
            this.Controls.Add(this.btn_firstRecord);
            this.Controls.Add(this.cb_monthSelector);
            this.Controls.Add(this.btn_newFriend);
            this.Controls.Add(this.btn_editFriend);
            this.Controls.Add(this.btn_deleteFriend);
            this.Controls.Add(this.btn_binarySearch);
            this.Controls.Add(this.btn_birthdayInMonthOf);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.tb_friendLikes);
            this.Controls.Add(this.tb_friendDislikes);
            this.Controls.Add(this.tb_birthDay);
            this.Controls.Add(this.tb_birthMonth);
            this.Controls.Add(this.tb_friendName);
            this.Controls.Add(this.tb_friendSearch);
            this.Controls.Add(this.btn_findFriend);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_findFriend;
        private System.Windows.Forms.TextBox tb_friendSearch;
        private System.Windows.Forms.TextBox tb_friendName;
        private System.Windows.Forms.TextBox tb_birthMonth;
        private System.Windows.Forms.TextBox tb_birthDay;
        private System.Windows.Forms.TextBox tb_friendDislikes;
        private System.Windows.Forms.TextBox tb_friendLikes;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_birthdayInMonthOf;
        private System.Windows.Forms.Button btn_binarySearch;
        private System.Windows.Forms.Button btn_deleteFriend;
        private System.Windows.Forms.Button btn_editFriend;
        private System.Windows.Forms.Button btn_newFriend;
        private System.Windows.Forms.ComboBox cb_monthSelector;
        private System.Windows.Forms.Button btn_firstRecord;
        private System.Windows.Forms.Button btn_lastRecord;
        private System.Windows.Forms.Button btn_nextRecord;
        private System.Windows.Forms.Button btn_previousRecord;
        private System.Windows.Forms.DataGridView dgv_friends;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Button btn_showAll;
        private System.Windows.Forms.TextBox tb_binarySearch;
        private System.Windows.Forms.Label label9;
    }
}


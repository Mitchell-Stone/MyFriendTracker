/*
 *      Student Number: 0111005906
 *      Name:           Mitchell Stone
 *      Date:           30/07/2018
 *      Purpose:        Properties for the Friends object
 *      Known Bugs:     None
 * */

using System;

namespace MyFriendTracker
{
    class Friend : IComparable<Friend>
    {
        //properties for the friend class
        public string Name { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }

        //Used for the binary search
        public int CompareTo(Friend other)
        {
            //
            return this.Name.ToUpper().CompareTo(other.Name.ToUpper());
        }
    }
}

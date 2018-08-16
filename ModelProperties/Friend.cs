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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A friend. </summary>
    ///
    /// <remarks>   , 16/08/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Friend : IComparable<Friend>
    {
        //properties for the friend class

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the likes. </summary>
        ///
        /// <value> The likes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Likes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dislikes. </summary>
        ///
        /// <value> The dislikes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Dislikes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the birth day. </summary>
        ///
        /// <value> The birth day. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BirthDay { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the birth month. </summary>
        ///
        /// <value> The birth month. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BirthMonth { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer
        /// that indicates whether the current instance precedes, follows, or occurs in the same position
        /// in the sort order as the other object.
        /// </summary>
        ///
        /// <remarks>   , 16/08/2018. </remarks>
        ///
        /// <param name="other">    An object to compare with this instance. </param>
        ///
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has
        /// these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" />
        /// in the sort order.  Zero This instance occurs in the same position in the sort order as
        /// <paramref name="other" />. Greater than zero This instance follows <paramref name="other" />
        /// in the sort order.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int CompareTo(Friend other)
        {
            //changes the input to upper case and compares the current friend to the friend entered.
            return this.Name.ToUpper().CompareTo(other.Name.ToUpper());
        }
    }
}

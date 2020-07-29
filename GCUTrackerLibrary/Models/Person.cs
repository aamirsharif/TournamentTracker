using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class Person
    {
        /// <summary>
        /// Represents the id of the person.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the first name of person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the Last Name of the Person
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the email address of the person
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Represents the mobile phone number of the person
        /// </summary>
        public string CellPhone { get; set; }

        /// <summary>
        /// Represents the Full Name of the Person
        /// </summary>
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public Person()
        {

        }

        /// <summary>
        /// Iitializes the person.
        /// </summary>
        /// <param name="fname">First Name of Person.</param>
        /// <param name="lname">Last Name of Person.</param>
        /// <param name="email">Email address of the person.</param>
        /// <param name="mobno">Mobile No of the Person.</param>
        public Person(string fname,string lname, string email, string mobno)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            CellPhone = mobno;
        }
    }
}

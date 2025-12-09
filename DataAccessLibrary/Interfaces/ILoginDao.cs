using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface ILoginDao
    {
        // User types are defined here, as it's expected all login implementations follow.
        enum UserRole
        {
            Undefined,
            Influencer,
            Company
        }

        /* Struct that holds basic user information.
         */
        public struct User
        {
            public string username;
            public UserRole role;

            public User(string username, string rolestring)
            {
                this.username = username;
                switch(rolestring)
                {
                    case "Influencer":
                        this.role = UserRole.Influencer;
                        break;
                    case "Company":
                        this.role = UserRole.Company;
                        break;
                    default:
                        this.role = UserRole.Undefined;
                        break;
                }
            }
        }

        public class InvalidLoginException : ArgumentException
        {
            public InvalidLoginException() : base() { }
            public InvalidLoginException(string message) : base(message) { }
            public InvalidLoginException(string message, Exception ex) : base(message, ex) { }
        }

        /* Method should attempt to log in to a user in whichever database is implemented.
         * Method should throw an InvalidLoginException, with an error message
         * that describes whether it was an incorrect username or password.
         * It is expected that the consumer handles confidentiality of incorrect username/password.
         * */
        public User AttemptLogin(string username, string password);
    }
}

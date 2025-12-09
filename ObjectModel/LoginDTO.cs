using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    /*  Data Transfer Object for logging in
     * 
     */
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginDTO(string username, string password)
        {
            Username = username;
            Password = password; 
        }
    }
}

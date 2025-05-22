using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRent
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    public static class UserStore
    {
        public static List<User> users = new List<User>();

        public static void AddUser(string username, string password)
        {
            users.Add(new User(username, password));
        }

        public static bool ValidateUser(string username, string password)
        {
            return users.Exists(u => u.Username == username && u.Password == password);
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {
        }
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public bool CheckUserInfo()
        {
           var user = App.UserDatabase.GetUser(UserName, Password);
            if (user != null)
                return true;
            else
                return false;
        }
    }
}

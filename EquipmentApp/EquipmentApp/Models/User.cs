using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.Models
{
    public class User
    {
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
            if (this.UserName == "oni" && this.Password == "oni")
                return true;
            else
                return false;
        }
    }
}

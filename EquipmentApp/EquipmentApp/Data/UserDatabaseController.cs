using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.Data
{
   public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection databse;

        public UserDatabaseController()
        {
            databse = DependencyService.Get<ISQLite>().GetConnection();
            databse.CreateTable<User>();
        }
        
        public User GetUser(string userName, string password)
        {
            lock (locker)
            {
                if(databse.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return databse.Table<User>()
                                  .Where(x => x.UserName == userName && x.Password == password)
                                  .FirstOrDefault();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if(user.Id != 0)
                {
                    databse.Update(user);
                    return user.Id;
                }
                else
                {
                    return databse.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return databse.Delete<User>(id);
            }
        }

    }
}

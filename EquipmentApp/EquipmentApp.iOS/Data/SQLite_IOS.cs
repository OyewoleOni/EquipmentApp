using EquipmentApp.Interfaces;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace EquipmentApp.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "EquipmentDB.db3";
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "...", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
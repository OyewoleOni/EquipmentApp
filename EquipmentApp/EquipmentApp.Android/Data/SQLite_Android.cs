using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EquipmentApp.Droid.Data;
using EquipmentApp.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace EquipmentApp.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android(){}
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "EquipmentDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
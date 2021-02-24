using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.Interfaces
{
    public interface ISQLite
    {
       SQLiteConnection GetConnection();
    }
}

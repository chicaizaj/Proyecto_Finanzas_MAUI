using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Finanzas_MAUI.Utilities
{
        
    //ruta donde se guardad SQLITE
    public static class Constants
    {
        public static string DatabasePath
        { get
            {
                var folderPath = FileSystem.AppDataDirectory;
                return Path.Combine(folderPath, "DB_FINANZAS.db3");
                }
            }

       public static SQLiteOpenFlags Flags =>
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
    }
}


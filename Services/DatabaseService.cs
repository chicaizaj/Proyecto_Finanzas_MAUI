using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Finanzas_MAUI.Models;
using Proyecto_Finanzas_MAUI.Utilities;
using Proyecto_Finanzas_MAUI.Views;
using SQLite;

namespace Proyecto_Finanzas_MAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService ()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<Usuario> ObtenerUsuarioAsync  (string nombreUsuario)
        {
            return _database.Table<Usuario>()
                            .Where(u => u.nombreusuario == nombreUsuario)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Usuario>> ObtenerTodosUsuariosAsync () 
        {
            return _database.Table<Usuario>().ToListAsync();
         }
     
    }   
}

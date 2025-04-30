using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Finanzas_MAUI.Models;
using Proyecto_Finanzas_MAUI.Utilities;

namespace Proyecto_Finanzas_MAUI.ViewModels
{
    internal class UsuarioViewModel
    {
        private SQLiteAsyncConnection _db;
        public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();
        
        public UsuarioViewModel()
        {
            _db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            LoadUsuarios();
        }

        public async void LoadUsuarios()
        {
            var lista = await _db.Table<Usuario>().ToListAsync();
            foreach(var user in lista)
            {
                Usuarios.Add(user);
            }
        }
    
    }
}


using Proyecto_Finanzas_MAUI.Models;
using Proyecto_Finanzas_MAUI.Services;
using Proyecto_Finanzas_MAUI.Utilities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Finanzas_MAUI.ViewModels
{
    public class LoginViewModel
    {
        private SQLiteAsyncConnection _database;
        
        public LoginViewModel()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
           

        }

        // Método para crear tabla e insertar usuario de prueba
        public async Task InicializarAsync()
        {
            await _database.CreateTableAsync<Usuario>();
            await InsertarUsuarioPrueba();
        }

        private async Task InsertarUsuarioPrueba()
        {
            var existente = await _database.Table<Usuario>()
                .Where(u => u.nombreusuario == "admin")
                .FirstOrDefaultAsync();

            if (existente == null)
            {
                var usuario = new Usuario
                {
                    nombreusuario = "admin",
                    contrasena = "1234",
                    rol = "Administrador"
                };

                await _database.InsertAsync(usuario);
            }
        }

        public async Task<bool> IniciarSesionAsync(string nombreUsuario, string contrasena)
        {
            var usuario = await _database.Table<Usuario>()
                            .Where(u => u.nombreusuario == nombreUsuario && u.contrasena == contrasena)
                            .FirstOrDefaultAsync();
             return usuario != null;
        }

      

    }
}
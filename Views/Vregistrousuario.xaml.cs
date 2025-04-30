using Proyecto_Finanzas_MAUI.Models;
using Proyecto_Finanzas_MAUI.Utilities;
using SQLite;
using System.Threading.Tasks;

namespace Proyecto_Finanzas_MAUI.Views;

public partial class Vregistrousuario : ContentPage
{

	private SQLiteAsyncConnection _database;
	public Vregistrousuario()
	{
		InitializeComponent();
        _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        _database.CreateTableAsync<Usuario>();
    }

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        string nombre = txtusuario.Text;
        string contrasena = txtcontrasena.Text; ;
        string rol = pickerRol.SelectedItem?.ToString() ?? "Usuario";

        if (string.IsNullOrEmpty(nombre)|| string.IsNullOrWhiteSpace (contrasena) )
        {
            await DisplayAlert("Error", "Complete todos los campos.", "OK");
            return;
        }

        var nuevo = new Usuario
        {
            nombreusuario = nombre,
            contrasena = contrasena,
            rol = rol
        };

        await _database.InsertAsync(nuevo);
        await DisplayAlert("Exito", "Usuario registrado.", "OK");
        
        await Navigation.PopAsync();
    }
}
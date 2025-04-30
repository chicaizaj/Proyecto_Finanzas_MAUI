using Proyecto_Finanzas_MAUI.ViewModels;
using System.Threading.Tasks;

namespace Proyecto_Finanzas_MAUI.Views;

public partial class VusuarioLogin : ContentPage
{
	private readonly LoginViewModel _ViewModel;
	public VusuarioLogin()
	{
		InitializeComponent();
		_ViewModel = new LoginViewModel();

        BindingContext = _ViewModel;

		InicializarViewModel();
    }

    private async void InicializarViewModel()
    {
        await _ViewModel.InicializarAsync();
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
		string nombreUsuario = txtnombre.Text;
		string contrasena = txtcontrasena.Text;

		bool exito = await _ViewModel.IniciarSesionAsync(nombreUsuario, contrasena);
		if(exito)
		{
			await DisplayAlert("Exito", "Inicio de sesion exitoso", "OK");

			await Navigation.PushAsync(new Vpantallainicio());
		}
		else {
			await DisplayAlert("ERROR", "Credenciales incorrectas", "OK");
		}
    }

    private async void Button_Registrar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Vregistrousuario());
    }
}
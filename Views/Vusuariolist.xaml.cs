namespace Proyecto_Finanzas_MAUI.Views;

public partial class Vusuariolist : ContentPage
{
	public Vusuariolist()
	{
		InitializeComponent();
		BindingContext = new ViewModels.UsuarioViewModel();
	}
}
using scaldasExamen.Models;

namespace scaldasExamen.Views;

public partial class ResumenPage : ContentPage
{
    public ResumenPage(ClienteData datos)
    {
        InitializeComponent();

        lblUsuarioConectado.Text = $"Usuario conectado: {datos.UsuarioConectado}";
        lblNombre.Text = datos.Nombre;
        lblApellido.Text = datos.Apellido;
        lblVA.Text = $"{datos.VA} VA";
        lblFecha.Text = datos.Fecha;
        lblCiudad.Text = datos.Ciudad;
        lblMontoInicial.Text = $"$ {datos.MontoInicial:F2}";
        lblCuotaMensual.Text = $"$ {datos.CuotaMensual:F2}";
        lblPagoTotal.Text = $"$ {datos.PagoTotal:F2}";
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert("Cerrar Sesión",
            "¿Está seguro que desea cerrar sesión?", "Sí", "No");

        if (confirmar)
            await Navigation.PopToRootAsync();
    }
}
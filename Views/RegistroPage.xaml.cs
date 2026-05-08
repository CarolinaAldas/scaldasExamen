using scaldasExamen.Models;

namespace scaldasExamen.Views;

public partial class RegistroPage : ContentPage
{
    private const double CostoUPS = 300.0;
    private const double PorcentajeInicial = 0.15;
    private const int NumCuotas = 3;
    private const double PorcentajeCuota = 0.05;

    private readonly string _usuarioConectado;
    private double _cuotaMensualCalculada = 0;

    public RegistroPage(string usuarioConectado)
    {
        InitializeComponent();
        _usuarioConectado = usuarioConectado;
        lblUsuarioConectado.Text = $"Usuario conectado: {_usuarioConectado}";
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        if (pickerVA.SelectedIndex < 0)
        {
            DisplayAlert("Error", "Seleccione el Voltiamperio (VA).", "Aceptar");
            return;
        }

        if (!double.TryParse(entryMontoInicial.Text, out double montoInicial) || montoInicial <= 0)
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido.", "Aceptar");
            return;
        }

        double resto = CostoUPS - montoInicial;                    // 300 - montoIngresado
        double cuotaBase = resto / NumCuotas;                      // resto / 3
        double cargoCuota = CostoUPS * PorcentajeCuota;            // 300 × 5% = 15
        _cuotaMensualCalculada = cuotaBase + cargoCuota;

        entryCuotaMensual.Text = _cuotaMensualCalculada.ToString("F2");
    }

    private async void OnVerResumenClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNombre.Text))
        { await DisplayAlert("Error", "Ingrese el nombre.", "Aceptar"); return; }

        if (string.IsNullOrWhiteSpace(entryApellido.Text))
        { await DisplayAlert("Error", "Ingrese el apellido.", "Aceptar"); return; }

        if (pickerVA.SelectedIndex < 0)
        { await DisplayAlert("Error", "Seleccione el VA.", "Aceptar"); return; }

        if (pickerCiudad.SelectedIndex < 0)
        { await DisplayAlert("Error", "Seleccione la ciudad.", "Aceptar"); return; }

        if (_cuotaMensualCalculada == 0)
        { await DisplayAlert("Error", "Primero calcule el pago mensual.", "Aceptar"); return; }

        double.TryParse(entryMontoInicial.Text, out double montoInicial);
        double pagoTotal = montoInicial + (_cuotaMensualCalculada * NumCuotas);

        var datos = new ClienteData
        {
            UsuarioConectado = _usuarioConectado,
            Nombre = entryNombre.Text.Trim(),
            Apellido = entryApellido.Text.Trim(),
            VA = pickerVA.SelectedItem?.ToString() ?? "",
            Fecha = $"{datePicker.Date.Value.Day:D2}/{datePicker.Date.Value.Month:D2}/{datePicker.Date.Value.Year}",
            Ciudad = pickerCiudad.SelectedItem?.ToString() ?? "",
            MontoInicial = montoInicial,
            CuotaMensual = _cuotaMensualCalculada,
            PagoTotal = pagoTotal
        };

        await Navigation.PushAsync(new ResumenPage(datos));
    }
}
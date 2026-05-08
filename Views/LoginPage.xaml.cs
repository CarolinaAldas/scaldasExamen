namespace scaldasExamen.Views;

public partial class LoginPage : ContentPage
{
    private readonly string[,] _credenciales = new string[3, 2]
    {
        { "estudiante2025", "moviles" },
        { "uisrael",        "2025"    },
        { "sistemas",       "2025_1"  }
    };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarSesionClicked(object sender, EventArgs e)
    {
        string usuario = entryUsuario.Text?.Trim() ?? "";
        string password = entryPassword.Text?.Trim() ?? "";

        bool valido = false;
        for (int i = 0; i < _credenciales.GetLength(0); i++)
        {
            if (_credenciales[i, 0] == usuario && _credenciales[i, 1] == password)
            {
                valido = true;
                break;
            }
        }

        if (valido)
            await Navigation.PushAsync(new RegistroPage(usuario));
        else
            await DisplayAlert("Error", "Usuario o contrasenna incorrecta.", "Aceptar");
    }

    private async void OnAcercaDeClicked(object sender, EventArgs e)
    {
        string usuarioActual = entryUsuario.Text?.Trim() ?? "(no conectado)";
        await Navigation.PushAsync(new AcercaDePage(usuarioActual));
    }
}
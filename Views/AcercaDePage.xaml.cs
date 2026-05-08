namespace scaldasExamen.Views;

public partial class AcercaDePage : ContentPage
{
    public AcercaDePage(string usuarioConectado)
    {
        InitializeComponent();
        lblUsuarioConectado.Text = $"Usuario conectado: {usuarioConectado}";
    }
}
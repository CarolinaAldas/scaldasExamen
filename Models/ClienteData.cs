namespace scaldasExamen.Models;

/// <summary>
/// Modelo de datos del cliente UPS - se pasa entre páginas
/// </summary>
public class ClienteData
{
    public string UsuarioConectado { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string VA { get; set; } = string.Empty;
    public string Fecha { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public double MontoInicial { get; set; }
    public double CuotaMensual { get; set; }
    public double PagoTotal { get; set; }
}
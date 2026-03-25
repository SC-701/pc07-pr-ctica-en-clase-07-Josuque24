using Abstracciones.Modelos.Servicio;

namespace Abstracciones.Interfaces.Servicios
{
    public interface ITipoCambioServicio
    {
        Task<Conversiones> ObtenerCambio();
    }
}

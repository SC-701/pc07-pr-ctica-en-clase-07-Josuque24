using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ISubCategoriasFlujo
    {
        Task<IEnumerable<SubCategoriaResponse>> Obtener();
    }
}

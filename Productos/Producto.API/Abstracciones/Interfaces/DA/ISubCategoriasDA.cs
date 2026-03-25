using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface ISubCategoriasDA
    {
        Task<IEnumerable<SubCategoriaResponse>> Obtener();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface ISubCategoriasController
    {
        Task  <IActionResult> Obtener();
    }
}

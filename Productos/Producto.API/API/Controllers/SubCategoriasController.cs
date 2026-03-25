using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriasController : ControllerBase, ISubCategoriasController
    {
        private ISubCategoriasFlujo _subCategoriasFlujo;
        private ILogger<ProductoController> _logger;

        public SubCategoriasController(ISubCategoriasFlujo subCategoriasFlujo, ILogger<ProductoController> logger)
        {
            _subCategoriasFlujo = subCategoriasFlujo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _subCategoriasFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }
    }
}

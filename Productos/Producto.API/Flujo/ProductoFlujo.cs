using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Abstracciones.Interfaces.Reglas;

namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {
        private IProductoDA _productoDA;
        private ITipoCambioReglas _TipoCambioReglas;

        public ProductoFlujo(IProductoDA productoDA, ITipoCambioReglas TipoCambioReglas)
        {
            _productoDA = productoDA;
            _TipoCambioReglas = TipoCambioReglas;
        }

        public Task<Guid> Agregar(ProductoRequest producto)
        {
          return _productoDA.Agregar(producto);
        }

        public Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
           return _productoDA.Editar(Id, producto);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
         return _productoDA.Eliminar(Id);
        }

        public Task<IEnumerable<ProductoResponse>> Obtener()
        {
          return _productoDA.Obtener();
        }

        public async Task<ProductoDetalle> Obtener(Guid Id)
        {
            var producto = await _productoDA.Obtener(Id);

            if (producto == null)
            {
                return null;
            }

            producto.PrecioUSD = await _TipoCambioReglas.conversionDivisas(producto.Precio);

            return producto;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        [Required(ErrorMessage ="Falta el agregar nombre")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Falta el agregar descripcion")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 100 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Falta el agregar Precio")]
        [Range(0.01, int.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Falta el agregar Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Falta el agregar codigo de barrras")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "El código de barras debe tener 6 dígitos numéricos")]
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public Guid IdSubCategoria { get; set; }
        public string SubCategoria { get; set; }
        public string Categoria { get; set; }
    }
    
    public class ProductoDetalle : ProductoResponse
    {
        public decimal PrecioUSD { get; set; }
    }
}
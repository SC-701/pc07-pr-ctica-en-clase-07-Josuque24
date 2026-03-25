namespace Abstracciones.Modelos
{
    public class SubCategoriasBase
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string Nombre { get; set; }
    }

    public class SubCategoriaResponse : SubCategoriasBase
    {
        
    }
}

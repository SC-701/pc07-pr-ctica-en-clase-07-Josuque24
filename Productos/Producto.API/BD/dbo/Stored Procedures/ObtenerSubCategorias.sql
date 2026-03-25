CREATE PROCEDURE ObtenerSubCategorias
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
         Id,
        IdCategoria,
        Nombre
    FROM SubCategorias
    
END
GO
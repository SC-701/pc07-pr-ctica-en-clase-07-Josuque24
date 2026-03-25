-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EditarProducto
@Id AS uniqueidentifier
,@IdSubCategoria AS uniqueidentifier
,@Nombre AS varchar(MAX)
,@Descripcion AS varchar(MAX)
,@Precio AS decimal (18,2)
,@Stock AS int
,@CodigoBarras  AS varchar(MAX)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    BEGIN  TRANSACTION
UPDATE [dbo].[Producto]
   SET 
      [IdSubCategoria] = @IdSubCategoria
      ,[Nombre] = @Nombre
      ,[Descripcion] = @Descripcion
      ,[Precio] = @Precio
      ,[Stock] = @Stock
      ,[CodigoBarras] = @CodigoBarras
 WHERE Id= @Id
 select @Id
 COMMIT TRANSACTION
END
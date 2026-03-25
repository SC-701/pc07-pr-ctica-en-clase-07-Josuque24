using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using DA.Repositorios;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DA
{
    public class SubCategoriasDA : ISubCategoriasDA
    {     
        private IRepositorioDapper _respositorioDapper;
        private SqlConnection _sqlConnection;
        public SubCategoriasDA(IRepositorioDapper repositorioDapper)
        {
            _respositorioDapper = repositorioDapper;
            _sqlConnection = _respositorioDapper.ObtenerRepositorio();
        }

        public async Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
            string query = @"ObtenerSubCategorias";
            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoriaResponse>(query);
            return resultadoConsulta;
        }
    }
}

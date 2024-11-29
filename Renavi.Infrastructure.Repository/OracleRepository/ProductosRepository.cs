using Dapper;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.Productos;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ProductosWebResponseDto>> GetList(ProductosWebDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name: "INPANTALLA", oracleDbType: OracleDbType.Int32, direction: ParameterDirection.Input, request.pantalla);
                dynamicParameters.Add(name : "OLISTA", oracleDbType: OracleDbType.RefCursor,direction: ParameterDirection.Output);
                return await conexion.QueryAsync<ProductosWebResponseDto>("PKGRNV_GENERAL.SPRRNV_LISTAR_CONTENIDO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

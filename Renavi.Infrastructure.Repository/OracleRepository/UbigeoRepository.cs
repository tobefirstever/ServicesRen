using Dapper;
using Oracle.ManagedDataAccess.Client;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UbigeoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<UbigeoEntity>> GetList()
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name : "ocUBG", oracleDbType : OracleDbType.RefCursor, direction : ParameterDirection.Output);
                return await conexion.QueryAsync<UbigeoEntity>("PKGRNV_UBIGEO.SPRRNV_LISTAR", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

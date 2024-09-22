using Dapper;
using Dapper.Oracle;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ParametroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ParametroEntity>> ObtenerParametro(string grupoParametros)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name: "pPAR", value: null, oracleDbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pSCODIGO", value: grupoParametros, oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input);
                return await conexion.QueryAsync<ParametroEntity>("PKGRNV_PARAMETRO.SPRRNV_LEER", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

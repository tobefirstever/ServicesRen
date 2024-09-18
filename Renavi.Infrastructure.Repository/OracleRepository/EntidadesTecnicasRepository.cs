using Dapper;
using Oracle.ManagedDataAccess.Client;
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
    public class EntidadesTecnicasRepository : IEntidadesTecnicasRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EntidadesTecnicasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<IEnumerable<EntidadesTecnicasEntity>> GetList()
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name: "ocGAR", oracleDbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
                return await conexion.QueryAsync<EntidadesTecnicasEntity>("PKGSTP_GARANTIA_CS_JOSE.SPRNSTP_PORTALFMV3", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

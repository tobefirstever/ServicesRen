using Dapper;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.SimuladorCuotas;
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
    public class SimuladorCuotasRepository : ISimuladorCuotasRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SimuladorCuotasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<SimuladorBancosTasasResponseDto>> GetList()
        {
            using (var conexion = _connectionFactory?.GetConnectionSQL())
            {
                var dynamicParameters = new UtilParameters();
                //dynamicParameters.Add( name : "ocGAR", oracleDbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
                return await conexion.QueryAsync<SimuladorBancosTasasResponseDto>("SPRCOF_LISTAR_BANCOS_TASAS", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

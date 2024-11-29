using Dapper;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.Agencia;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AgenciaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<AgenciaResponseDto>> GetList()
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name : "OLISTA", oracleDbType : OracleDbType.RefCursor, direction : ParameterDirection.Output);
                return (List<AgenciaResponseDto>)await conexion.QueryAsync<AgenciaResponseDto>("PKGRNV_AGENCIAS.SPRRNV_LISTAR_AGENCIAS", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

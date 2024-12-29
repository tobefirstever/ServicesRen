using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Renavi.Application.DTO.Dtos.Metrica;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Renavi.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class MetricasRepository : IMetricasRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MetricasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<MetricaResponseDto> InsertMetrica(MetricaDto request)
        {
            OracleString mensaje = "";
            MetricaResponseDto response = new MetricaResponseDto();
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name: "pCMTA_IDVIDEO", oracleDbType: OracleDbType.Int32, direction: ParameterDirection.Input,request.Idvideo);
                dynamicParameters.Add(name: "pCMTA_FVIDEO", oracleDbType: OracleDbType.Int32, direction: ParameterDirection.Input, request.Flag_saltar);
                dynamicParameters.Add(name: "pCMTA_FSALTAR", oracleDbType: OracleDbType.Int32, direction: ParameterDirection.Input, request.Flag_visita);
                dynamicParameters.Add(name: "pMSG", null, dbType: DbType.String, direction: ParameterDirection.Output, 200);
                var result = conexion.ExecuteAsync("PKGRNV_METRICAS.SPRRNV_REGISTRAR_METRICA", param: dynamicParameters, commandType: CommandType.StoredProcedure);


                response.mensaje = dynamicParameters.dynamicParameters.Get<string>("pMSG");
               // mensaje = dynamicParameters.oracleDynamicParameters.Get<OracleString>("pMSG");
                response.valido = true;
                // return await conexion.QueryAsync<MetricaDto>("PKGRNV_METRICAS.SPRRNV_REGISTRAR_METRICA", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }

            return response;
        }
    }
}

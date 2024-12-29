using Dapper;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.Interaccion;
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
    public class InteraccionRepository : IInteraccionRepository
    {


        private readonly IConnectionFactory _connectionFactory;

        public InteraccionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<InteraccionResponseDto> InsertInteraccion(InteraccionDto request)
        {
            InteraccionResponseDto response = new InteraccionResponseDto();
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name: "pinIP", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.Ip);
                dynamicParameters.Add(name: "pinACCION", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.Accion);
                dynamicParameters.Add(name: "pinNAVEGADOR", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.Navegador);
                dynamicParameters.Add(name: "pinUSUARIO", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.UsuarioRegistro);
                dynamicParameters.Add(name: "pinCONTENIDO", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.Contenido);
                dynamicParameters.Add(name: "pinTIPO_CONTENIDO", oracleDbType: OracleDbType.Int32, direction: ParameterDirection.Input, request.TipoContenido);
                dynamicParameters.Add(name: "pinNOMBRE_METODO", oracleDbType: OracleDbType.Varchar2, direction: ParameterDirection.Input, request.Metodo);
               // dynamicParameters.Add(name: "pMSG", null, dbType: DbType.String, direction: ParameterDirection.Output, 200);

                var result = conexion.ExecuteAsync("PKGRNV_INTERACCION.SPRRNV_REGISTRAR", param: dynamicParameters, commandType: CommandType.StoredProcedure);


                response.mensaje = "ok";
                // mensaje = dynamicParameters.oracleDynamicParameters.Get<OracleString>("pMSG");
                response.valido = true;
                // return await conexion.QueryAsync<MetricaDto>("PKGRNV_METRICAS.SPRRNV_REGISTRAR_METRICA", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }

            return response;
        }
    }
}

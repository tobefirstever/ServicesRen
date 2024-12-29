using Dapper;
using Renavi.Domain.Entities.Entities;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public DireccionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<DireccionEntity> RegistrarDireccion(DireccionEntity direccionEntity)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add(name: "pCDIR_ID_TIPOVIA", value: direccionEntity.IdTipoVia, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_NOMBRE", value: direccionEntity.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_NRO", value: direccionEntity.Nro, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_MANZAN", value: direccionEntity.Mza, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_LOTE", value: direccionEntity.Lote, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_DEP", value: direccionEntity.IdDepartamento, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_PROV", value: direccionEntity.IdProvincia, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_DIST", value: direccionEntity.IdDistrito, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_TIPODOM", value: direccionEntity.IdTipoDomicilio, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_REFERENCIA", value: direccionEntity.DireccionReferencia, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_COD_POSTAL", value: direccionEntity.CodigoPostal, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pNDIR_LATITUD", value: direccionEntity.Latitud, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pNDIR_LONGITUD", value: direccionEntity.Longitud, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_USU_REG", value: direccionEntity.UsuarioRegistro, dbType: DbType.String, direction: ParameterDirection.Input);

                dynamicParameters.Add(name: "pCDIR_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_REGISTRAR_DIRECCION", dynamicParameters, commandType: CommandType.StoredProcedure);
                string mensaje = dynamicParameters.Get<string>("pMSG");

                if (mensaje != "OK")
                {
                    throw new ArgumentException(mensaje);
                }

                direccionEntity.IdDireccion = dynamicParameters.Get<int>("pCDIR_ID");

                return direccionEntity;
            }
        }
    }
}

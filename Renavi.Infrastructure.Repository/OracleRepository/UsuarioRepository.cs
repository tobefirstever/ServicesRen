using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.Usuario;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetList()
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new UtilParameters();
                dynamicParameters.Add(name : "ocGAR", oracleDbType:  OracleDbType.RefCursor, direction: ParameterDirection.Output);
                return await conexion.QueryAsync<UsuarioEntity>("PKGSTP_GARANTIA_CS_JOSE.SPRNSTP_PORTALFMV3", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<UsuarioResponseDto> RegistroUsuario(UsuarioDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                var response = new UsuarioResponseDto();

                dynamicParameters.Add(name: "pCPER_ID_DOCUMENTO", value: request.IdDocumento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NRO_DOCUMENTO", value: request.NumeroDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NOMBRE", value: request.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_PATERNO", value: request.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_MATERNO", value: request.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_CORREO", value: request.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NROCELULAR", value: request.Celular, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pUSU_CONTRASENA", value: request.Contrasena, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pUSU_REG", value: request.UsuarioCreacion, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCUS_CODIGO_VERIFICACION", value: request.CodigoVerificacion, dbType: DbType.Int32, direction: ParameterDirection.Input);

                dynamicParameters.Add(name: "pCUS_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pCPER_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_REGISTRAR_USUARIO", dynamicParameters, commandType: CommandType.StoredProcedure);
                response.IdUsuario = dynamicParameters.Get<int>("pCUS_ID");
                response.IdPersona = dynamicParameters.Get<int>("pCPER_ID");
                response.Mensaje = dynamicParameters.Get<string>("pMSG");


                return response;
            }
        }

        public async Task<UsuarioGeneralResponseDto> EnvioCorreoPassword(UsuarioCorreonDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                var response = new UsuarioGeneralResponseDto();

                dynamicParameters.Add(name: "pUSU_DOCUMENTO", value: request.NumeroDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pUSU_CORREO", value: request.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_GENERAR_VERIFICACION", dynamicParameters, commandType: CommandType.StoredProcedure);
                response.Mensaje = dynamicParameters.Get<string>("pMSG");

                if (response.Mensaje != "OK")
                {
                    throw new ArgumentException(response.Mensaje);
                }

                return response;
            }
        }

        public async Task<UsuarioGeneralResponseDto> ActualizarPassword(UsuarioACtualizarDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                var response = new UsuarioGeneralResponseDto();

                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);


                dynamicParameters.Add(name: "pUSU_ID_USUARIO", value: request.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pUSU_CONTRASENA", value: request.NuevaContrasena, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pUSU_ACT", value: request.UsuarioCreacion, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_ACTUALIZAR_CONTRASENA", dynamicParameters, commandType: CommandType.StoredProcedure);

                response.Mensaje = dynamicParameters.Get<string>("pMSG");

                if (response.Mensaje != "OK")
                {
                    throw new ArgumentException(response.Mensaje);
                }

                return response;
            }
        }


        public async Task<UsuarioAutenticacionResponseDto> Login(UsuarioAutenticacionDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add(name: "pUSU_NOMBRE", value: request.NumeroDocumento, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pPERFIL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var response= await conexion.QueryAsync<UsuarioAutenticacionResponseDto>("PKGRNV_PERFIL.SPRRNV_AUTENTICAR_USUARIO", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return response.FirstOrDefault();
            }
        }
    }
}

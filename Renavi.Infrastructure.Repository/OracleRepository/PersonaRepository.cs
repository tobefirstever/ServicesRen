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
using System;
using System.Linq;
using Renavi.Application.DTO.Dtos.Usuario;

namespace Renavi.Infrastructure.Repository.OracleRepository
{
   public  class PersonaRepository:IPersonaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PersonaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> RegistrarPersona(PersonaEntity personaEntity)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add(name: "pCPER_ID_DOCUMENTO", value: personaEntity.IdTipoDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NOMBRE", value: personaEntity.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_PATERNO", value: personaEntity.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_MATERNO", value: personaEntity.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_USU_REG", value: personaEntity.UsuarioRegistro, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCPER_ID_DIRECCION", value: personaEntity.DireccionDomicilio.IdDireccion, dbType: DbType.String, direction: ParameterDirection.Input);
                //dynamicParameters.Add(name: "pCPER_ID_CONTACTO", value: personaEntity.InformacionContacto.IdContacto, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NRO_DOCUMENTO", value: personaEntity.NroDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCUSU_ID", value: personaEntity.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);

                dynamicParameters.Add(name: "pCPER_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_REGISTRAR_PERSONA", dynamicParameters, commandType: CommandType.StoredProcedure);
                string mensaje = dynamicParameters.Get<string>("pMSG");

                if (mensaje != "OK")
                {
                    throw new ArgumentException(mensaje);
                }

                return dynamicParameters.Get<int>("pCPER_ID");
            }
        }

        public async Task<PersonaEntity> ObtenerPersona(int id)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add(name: "pCPER_ID", value: id, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pPERFIL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var persona = await conexion.QueryAsync<PersonaEntity, DireccionEntity, PersonaEntity>(
                    "PKGRNV_PERFIL.SPRRNV_LEER_PERFIL",
                    (personaEntity, direccionEntity) =>
                    {
                        personaEntity.DireccionDomicilio = direccionEntity;
                       // personaEntity.InformacionContacto = contactoEntity;
                        return personaEntity;
                    },
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "CDIR_ID"
                );

                return persona.FirstOrDefault();
            }
        }

        public async Task<string> ActualizarPersona(EditarPerfilModel personaEntity)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add(name: "pCPER_ID", value: personaEntity.IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCPER_ID_DOCUMENTO", value: personaEntity.IdDocumento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NOMBRE", value: personaEntity.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_PATERNO", value: personaEntity.ApellidoPaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_APELLIDO_MATERNO", value: personaEntity.ApellidoMaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_NROCELULAR", value: personaEntity.NroCelular, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSPER_PER_CORREO", value: personaEntity.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_TIPOVIA", value: personaEntity.IdTipoVia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_NOMBRE", value: personaEntity.NombreDireccion, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_DEP", value: personaEntity.IdDepartamento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_PROV", value: personaEntity.IdProvincia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCDIR_ID_DIST", value: personaEntity.IdDistrito, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_REFERENCIA", value: personaEntity.Referencia, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSDIR_USU_REG", value: personaEntity.NombreUsuario, dbType: DbType.String, direction: ParameterDirection.Input);


                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_ACTUALIZAR_PERFIL", dynamicParameters, commandType: CommandType.StoredProcedure);
                string mensaje = dynamicParameters.Get<string>("pMSG");

                if (mensaje != "OK")
                {
                    throw new ArgumentException(mensaje);
                }

                return mensaje;
            }
        }
    }
}

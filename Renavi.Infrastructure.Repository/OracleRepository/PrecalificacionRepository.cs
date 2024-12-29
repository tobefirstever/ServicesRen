using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Renavi.Application.DTO.Dtos.Precalificacion;
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
    public class PrecalificacionRepository : IPrecalificacionRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PrecalificacionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ObtenerPrecalificacionResponseDto> GetPrecalificacion(ObtenerPrecalificacionDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                try
                {
                    var dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add(name: "pCPER_ID", value: request.idpersona, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pCPRE_ID", value: request.idprecalificacion, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pPRECALIFICACION", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var response =  await conexion.QueryAsync<ObtenerPrecalificacionResponseDto>("PKGRNV_PRECALIFICACION.SPRRNV_LEER_PRECALIFICACION", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return response.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<ObtenerRespuestaResponseDto> GetRespuesta(ObtenerRespuestaDto request)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                try
                {
                    var dynamicParameters = new OracleDynamicParameters();
                    dynamicParameters.Add(name: "pTipo", value: request.Tipo, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pIngresoNetoFamiliarMensual", value: request.ingresonetofamiliarmensual, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pSituacionVivienda", value: request.situacionvivienda, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pFlagViviendaInscritaRegistrosPublicos", value: request.flagviviendainscritaregistrospublicos ? 1 : 0, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pFlagApoyoDelEstadoParaviviendaAntes", value: request.flagapoyodelestadoparaviviendaantes ? 1 : 0, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pPRECALIFICACION", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                    var response = await conexion.QueryAsync<ObtenerRespuestaResponseDto>("PKGRNV_PRECALIFICACION.SPRRNV_OBTENER_PRECALIFICACION", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    return response.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<PrecalificacionResponseDto> InsertarPrecalificacion(PrecalificacionDto request)
        {

            try
            {
                using (var conexion = _connectionFactory?.GetConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    var response = new PrecalificacionResponseDto();

                    dynamicParameters.Add(name: "pNumeroPantalla", value: request.NumeroPantalla, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pIdUsuario", value: request.IdUsuario, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pIdPersona", value: request.IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pIdPrecalificacion", value: request.IdPrecalificacion, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pTipoVia", value: request.TipoVia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pTipoDomicilio", value: request.TipoDomicilio, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pDescripcionTipoVia", value: request.DescripcionTipoVia, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pDepartamento", value: request.Departamento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pProvincia", value: request.Provincia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pDistrito", value: request.Distrito, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pNumero", value: request.Numero, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pManzana", value: request.Manzana, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pLote", value: request.Lote, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pReferencia", value: request.Referencia, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pLatitud", value: request.Latitud, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pLongitud", value: request.Longitud, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pGenero", value: request.Genero, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pEstadoCivil", value: request.EstadoCivil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pNacionalidad", value: request.Nacionalidad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pEdad", value: request.Edad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pLugarDondeResideActualmente", value: request.LugarDondeResideActualmente, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pHogarConformadoPorEstasPersonas", value: request.HogarConformadoPorEstasPersonas, dbType: DbType.String, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pQueNecesita", value: request.QueNecesita, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pPrincipalDepartamento", value: request.Principal_Departamento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pPrincipalProvincia", value: request.Principal_Provincia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pPrincipalDistrito", value: request.Principal_Distrito, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pIngresoNetoFamiliarMensual", value: request.IngresoNetoFamiliarMensual, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pSituacionVivienda", value: request.SituacionVivienda, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pFlagViviendaInscritaRegistrosPublicos", value: request.FlagViviendaInscritaRegistrosPublicos ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    dynamicParameters.Add(name: "pFlagApoyoDelEstadoParaviviendaAntes", value: request.FlagApoyoDelEstadoParaviviendaAntes ? 1 : 0, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    dynamicParameters.Add(name: "ppPRE_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    await conexion.ExecuteAsync("PKGRNV_PRECALIFICACION.SPRRNV_REGISTRAR_PRECALIFICACION", dynamicParameters, commandType: CommandType.StoredProcedure);
                    response.idPrecalificacion = dynamicParameters.Get<int>("ppPRE_ID");
                    response.Mensaje = dynamicParameters.Get<string>("pMSG");


                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        }
    }


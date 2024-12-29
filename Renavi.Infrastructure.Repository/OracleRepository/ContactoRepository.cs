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
    public class ContactoRepository : IContactoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ContactoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ContactoEntity> RegistrarContacto(ContactoEntity contactoEntity)
        {
            using (var conexion = _connectionFactory?.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add(name: "pSCNT_NROCELULAR", value: contactoEntity.NroCelular, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSCNT_CORREO", value: contactoEntity.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pSCNT_USU_REG", value: contactoEntity.UsuarioRegistro, dbType: DbType.String, direction: ParameterDirection.Input);
                dynamicParameters.Add(name: "pCCNT_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add(name: "pMSG", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await conexion.ExecuteAsync("PKGRNV_PERFIL.SPRRNV_REGISTRAR_CONTACTO", dynamicParameters, commandType: CommandType.StoredProcedure);
                string mensaje = dynamicParameters.Get<string>("pMSG");

                if (mensaje != "OK")
                {
                    throw new ArgumentException(mensaje);
                }

                contactoEntity.IdContacto = dynamicParameters.Get<int>("pCCNT_ID");
                return contactoEntity;
            }
        }
    }
}

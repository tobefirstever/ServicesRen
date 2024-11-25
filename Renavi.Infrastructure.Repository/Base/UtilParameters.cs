using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;


namespace Renavi.Infrastructure.Repository.Base
{
    public class UtilParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();
       

      

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null)
        {
            OracleParameter oracleParameter;

            if (value != null)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType, direction);
            }
            oracleParameters.Add(oracleParameter);
        }


      

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }

        

    }
}

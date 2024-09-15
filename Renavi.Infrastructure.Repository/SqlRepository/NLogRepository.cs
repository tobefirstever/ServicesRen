using Renavi.Domain.Entities.Custom;
using Renavi.Infrastructure.Interfaces.Configuration;
using Renavi.Infrastructure.Interfaces.Repository;
using Dapper;
using System.Data;
using System.Collections.Generic;
using Renavi.Infrastructure.Repository.ProcedimientosAlmacenados;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Repository.SqlRepository
{
    public class NLogRepository : INLogRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public NLogRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Add(NLog nLog)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                if (nLog == null) return;

                dynamicParameters.Add(ProcedimientoNLog.Hostname, nLog.Hostname);
                dynamicParameters.Add(ProcedimientoNLog.Mensaje, nLog.Mensaje);

                conexion.Execute(ProcedimientoNLog.NLogInsert, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddAsync(NLog nLog)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                if (nLog == null) return;

                dynamicParameters.Add(ProcedimientoNLog.Hostname, nLog.Hostname);
                dynamicParameters.Add(ProcedimientoNLog.Mensaje, nLog.Mensaje);

                await conexion.ExecuteAsync(ProcedimientoNLog.NLogInsert, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.Id, id);

                conexion.Execute(ProcedimientoNLog.NLogDelete, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.Id, id);

                await conexion.ExecuteAsync(ProcedimientoNLog.NLogDelete, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NLog> GetAll()
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                return conexion.Query<NLog>(ProcedimientoNLog.NLogGetAll, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<NLog>> GetAllAsync()
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                return await conexion.QueryAsync<NLog>(ProcedimientoNLog.NLogGetAll, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<NLog> GetAllPaging(int pageNumber, int pageSize)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.PageNumber, pageNumber);
                dynamicParameters.Add(ProcedimientoNLog.PageSize, pageSize);
                return conexion.Query<NLog>(ProcedimientoNLog.NLogGetAllPaging, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<NLog>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.PageNumber, pageNumber);
                dynamicParameters.Add(ProcedimientoNLog.PageSize, pageSize);
                return await conexion.QueryAsync<NLog>(ProcedimientoNLog.NLogGetAllPaging, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public NLog GetById(int id)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.Id, id);

                return conexion.QuerySingleOrDefault<NLog>(ProcedimientoNLog.NLogGetById, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<NLog> GetByIdAsync(int id)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add(ProcedimientoNLog.Id, id);

                return await conexion.QuerySingleOrDefaultAsync<NLog>(ProcedimientoNLog.NLogGetById, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(NLog nLog)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                if (nLog == null) return;

                dynamicParameters.Add(ProcedimientoNLog.Id, nLog.Id);
                dynamicParameters.Add(ProcedimientoNLog.Hostname, nLog.Hostname);
                dynamicParameters.Add(ProcedimientoNLog.Mensaje, nLog.Mensaje);

                conexion.Execute(ProcedimientoNLog.NLogUpdate, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync(NLog nLog)
        {
            using (var conexion = _connectionFactory.GetConnection())
            {
                var dynamicParameters = new DynamicParameters();
                if (nLog == null) return;

                dynamicParameters.Add(ProcedimientoNLog.Id, nLog.Id);
                dynamicParameters.Add(ProcedimientoNLog.Hostname, nLog.Hostname);
                dynamicParameters.Add(ProcedimientoNLog.Mensaje, nLog.Mensaje);

                await conexion.ExecuteAsync(ProcedimientoNLog.NLogUpdate, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

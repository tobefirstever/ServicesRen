using Renavi.Application.DTO;
using Renavi.Application.Interfaces;
using Renavi.Domain.Interfaces;
using Custom = Renavi.Domain.Entities.Custom;
using Renavi.Transversal.Common;
using Renavi.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Threading.Tasks;

namespace Renavi.Application.Main
{
    public class NLogApplication : BaseClass, INLogApplication
    {
        private readonly INLogDomain _nLogDomain;

        public NLogApplication(INLogDomain nLogDomain)
        {
            _nLogDomain = nLogDomain;
        }

        public Response<bool> Add(NLogForCreationRequestDto nLogForCreationRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    if (nLogForCreationRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    _nLogDomain?.Add(Mapping.Map<NLogForCreationRequestDto, Custom.NLog>(nLogForCreationRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public async Task<Response<bool>> AddAsync(NLogForCreationRequestDto nLogForCreationRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion), 
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options,TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (nLogForCreationRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    if (_nLogDomain != null)
                        await _nLogDomain?.AddAsync(
                            Mapping.Map<NLogForCreationRequestDto, Custom.NLog>(nLogForCreationRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public Response<bool> Delete(int id)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    _nLogDomain?.Delete(id);
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options,TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (_nLogDomain != null) await _nLogDomain?.DeleteAsync(id);
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public Response<IEnumerable<NLogDto>> GetAll()
        {
            var respuesta = new Response<IEnumerable<NLogDto>> { Data = new List<NLogDto>() };
            try
            {
                IEnumerable<Custom.NLog> nlogList = _nLogDomain.GetAll();
                respuesta.Data = Mapping.Map<IEnumerable<Custom.NLog>, IEnumerable<NLogDto>>(nlogList);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public async Task<Response<IEnumerable<NLogDto>>> GetAllAsync()
        {
            var respuesta = new Response<IEnumerable<NLogDto>> { Data = new List<NLogDto>() };
            try
            {
                IEnumerable<Custom.NLog> nlogList = await _nLogDomain.GetAllAsync();
                respuesta.Data = Mapping.Map<IEnumerable<Custom.NLog>, IEnumerable<NLogDto>>(nlogList);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public Response<IEnumerable<NLogDto>> GetAllPaging(int pageNumber, int pageSize)
        {
            var respuesta = new Response<IEnumerable<NLogDto>> { Data = new List<NLogDto>() };
            try
            {
                IEnumerable<Custom.NLog> nlogList = _nLogDomain.GetAllPaging(pageNumber, pageSize);
                respuesta.Data = Mapping.Map<IEnumerable<Custom.NLog>, IEnumerable<NLogDto>>(nlogList);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public async Task<Response<IEnumerable<NLogDto>>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            var respuesta = new Response<IEnumerable<NLogDto>> { Data = new List<NLogDto>() };
            try
            {
                IEnumerable<Custom.NLog> nlogList = await _nLogDomain.GetAllPagingAsync(pageNumber, pageSize);
                respuesta.Data = Mapping.Map<IEnumerable<Custom.NLog>, IEnumerable<NLogDto>>(nlogList);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public Response<NLogDto> GetById(int id)
        {
            var respuesta = new Response<NLogDto> { Data = new NLogDto() };
            try
            {
                Custom.NLog nlog = _nLogDomain.GetById(id);
                respuesta.Data = Mapping.Map<Custom.NLog, NLogDto>(nlog);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public async Task<Response<NLogDto>> GetByIdAsync(int id)
        {
            var respuesta = new Response<NLogDto> { Data = new NLogDto() };
            try
            {
                Custom.NLog nlog = await _nLogDomain.GetByIdAsync(id);
                respuesta.Data = Mapping.Map<Custom.NLog, NLogDto>(nlog);
            }
            catch (Exception exception)
            {
                respuesta.IsSuccess = false;
                respuesta.Message = Mensajes.ErrorEnconsulta;
                Logger?.Error(exception, exception.Message);
            }

            return respuesta;
        }

        public Response<bool> Update(NLogForUpdateRequestDto nLogForUpdateRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    if (nLogForUpdateRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    _nLogDomain?.Update(Mapping.Map<NLogForUpdateRequestDto, Custom.NLog>(nLogForUpdateRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(NLogForUpdateRequestDto nLogForUpdateRequestDto)
        {
            var response = new Response<bool>();

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = TimeSpan.FromTicks(Constantes.TimeoutTransaccion)
            };

            using (var transaccion = new TransactionScope(TransactionScopeOption.Required, options,TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (nLogForUpdateRequestDto == null)
                    {
                        response.IsWarning = true;
                        response.Message = Mensajes.ErrorAlRegistrarDataInvalida;
                        return response;
                    }

                    if (_nLogDomain != null)
                        await _nLogDomain?.UpdateAsync(
                            Mapping.Map<NLogForUpdateRequestDto, Custom.NLog>(nLogForUpdateRequestDto));
                    response.Data = true;
                    transaccion.Complete();
                }
                catch (Exception exception)
                {
                    response.IsSuccess = false;
                    response.Message = Mensajes.ErrorEnconsulta;
                    Logger?.Error(exception, exception.Message);
                }
            }

            return response;
        }
    }
}

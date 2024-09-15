namespace Renavi.Infrastructure.Repository.ProcedimientosAlmacenados
{
    public static class ProcedimientoNLog
    {
        #region Procedimientos
        public static readonly string NLogInsert = "NLogInsert";
        public static readonly string NLogUpdate = "NLogUpdate";
        public static readonly string NLogDelete = "NLogDelete";
        public static readonly string NLogGetById = "NLogGetById";
        public static readonly string NLogGetAll = "NLogGetAll";
        public static readonly string NLogGetAllPaging = "NLogGetAllPaging";
        #endregion

        #region Parámetros
        public static readonly string Id = "@Id";
        public static readonly string Hostname = "@Hostname";
        public static readonly string Mensaje = "@Mensaje";
        public static readonly string PageNumber = "@PageNumber";
        public static readonly string PageSize = "@PageSize";        
        #endregion
    }
}

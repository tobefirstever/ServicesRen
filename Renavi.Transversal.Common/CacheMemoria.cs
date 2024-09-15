using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Renavi.Transversal.Common
{
    public class CacheMemoria<C, V> : IDisposable
    {

        public CacheMemoria()
        { }

        readonly ObjectCache cache = MemoryCache.Default;
        private readonly ReaderWriterLockSlim bloqueo = new ReaderWriterLockSlim();

        public void Agregar(C clave, V objetoValor, double expiracionSegundos)
        {
            CacheItemPolicy politicaCache = new CacheItemPolicy();

            politicaCache.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expiracionSegundos);

            bloqueo.EnterWriteLock();
            try
            {
                cache.Set(clave.ToString(), objetoValor, politicaCache);
            }
            finally
            { bloqueo.ExitWriteLock(); }
        }

        public V Leer(C clave)
        {
            bloqueo.EnterReadLock();
            try
            {
                return (V)cache.Get(clave.ToString());
            }
            finally
            { bloqueo.ExitReadLock(); }
        }

        public object Eliminar(C clave)
        {
            bloqueo.EnterWriteLock();
            try
            {
                return cache.Remove(clave.ToString());
            }
            finally
            { bloqueo.ExitWriteLock(); }
        }

        public bool Existe(C clave)
        {

            return cache.Contains(clave.ToString());

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
        }

    }
}

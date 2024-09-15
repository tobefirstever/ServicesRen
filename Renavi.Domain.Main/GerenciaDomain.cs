using Renavi.Domain.Entities.Entities;
using Renavi.Domain.Interfaces;
using Renavi.Infrastructure.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Domain.Main
{
    public class GerenciaDomain : IGerenciaDomain
    {
        private readonly IGerenciaRepository _gerenciaRepository;

        public GerenciaDomain(IGerenciaRepository gerenciaRepository)
        {
            _gerenciaRepository = gerenciaRepository;
        }

        public async Task<IEnumerable<GerenciaEntity>> GetList()
        {
            return await _gerenciaRepository?.GetList();
        }
    }
}

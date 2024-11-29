using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renavi.Infrastructure.Interfaces.Configuration
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
        string GetConnectionStringSQL();
    }
}

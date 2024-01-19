using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Intefaces.DataStores
{
    public interface IUnitofWork : IDisposable
    {
        public Task<int> SaveChangesAsync();
    }
}

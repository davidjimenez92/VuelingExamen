using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExamen.Infrastructure.Repositories.Contracts
{
    public interface IAdd<T>
    {
        bool Add(T entity);
    }
}

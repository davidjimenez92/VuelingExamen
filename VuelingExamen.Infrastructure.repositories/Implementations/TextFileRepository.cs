using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;

namespace VuelingExamen.Infrastructure.Repositories.Implementations
{
    public class TextFileRepository : IFileRepository<Registry>
    {
        public bool Add(Registry entity)
        {
            throw new NotImplementedException();
        }
    }
}

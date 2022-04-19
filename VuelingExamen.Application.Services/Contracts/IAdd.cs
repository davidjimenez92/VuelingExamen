using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.CrossCutting.ProjectConfiguration;

namespace VuelingExamen.Application.Services.Contracts
{
    public interface IAdd<T>
    {
        bool Add(T dto, FileType type);
    }
}

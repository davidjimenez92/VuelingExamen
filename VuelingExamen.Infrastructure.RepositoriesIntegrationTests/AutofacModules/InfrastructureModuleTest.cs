using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;
using VuelingExamen.Infrastructure.Repositories.Implementations;

namespace VuelingExamen.Infrastructure.RepositoriesIntegrationTests.AutofacModules
{
    public class InfrastructureModuleTest: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextFileRepository>()
                .As<IFileRepository<Registry>>();

            base.Load(builder);
        }
    }
}

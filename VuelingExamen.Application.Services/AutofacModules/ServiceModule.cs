using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.CrossCutting.ProjectConfiguration;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;
using VuelingExamen.Infrastructure.Repositories.Implementations;

namespace VuelingExamen.Application.Services.AutofacModules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextFileRepository>()
                .As<IFileRepository<Registry>>()
                .Keyed<IFileRepository<Registry>>(FileType.Text)
                .InstancePerDependency();

            builder.Register<Func<FileType, IFileRepository<Registry>>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (type) =>
                 {
                     var fileRepository = componentContext.ResolveKeyed<IFileRepository<Registry>>(type);
                     return fileRepository;
                 };
            });

            base.Load(builder);
        }
    }
}

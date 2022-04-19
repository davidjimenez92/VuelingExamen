using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.Application.Services.Implementations;

namespace VuelingExamen.Application.ServicesIntegrationTests.AutofacModule
{
    public class ServicesModuleTest: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VuelingRegisterService>()
                .As<IVuelingService<RegistryDto>>();

            base.Load(builder);
        }
    }
}

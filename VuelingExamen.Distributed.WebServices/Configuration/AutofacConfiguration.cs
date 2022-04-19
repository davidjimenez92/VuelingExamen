using Autofac;
using Autofac.log4net;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Application.Services.AutofacModules;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.Application.Services.Implementations;
using VuelingExamen.Application.Services.Profiles;
using VuelingExamen.Distributed.WebServices.Contracts;

namespace VuelingExamen.Distributed.WebServices.Configuration
{
    public static class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceProfile>();

            })).AsSelf().SingleInstance();

            builder.Register(context =>
            {
                var con = context.Resolve<IComponentContext>();
                var config = con.Resolve<MapperConfiguration>();
                return config.CreateMapper(con.Resolve);
            })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterModule<Log4NetModule>();
            builder.RegisterModule(new ServiceModule());


            builder.RegisterType<VuelingWebService>()
                .As<IVuelingWebService>();
            builder.RegisterType<VuelingRegisterService>()
                .As<IVuelingService<RegistryDto>>();

            return builder.Build();
        }
    }
}
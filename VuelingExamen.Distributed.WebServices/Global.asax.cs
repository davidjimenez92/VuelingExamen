using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using VuelingExamen.Distributed.WebServices.Configuration;

namespace VuelingExamen.Distributed.WebServices
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            IContainer container = AutofacConfiguration.Configure();
            AutofacHostFactory.Container = container;
        }
    }
}
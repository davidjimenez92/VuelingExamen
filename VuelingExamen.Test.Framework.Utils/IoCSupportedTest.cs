using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExamen.Test.Framework.Utils
{
	public class IoCSupportedTest<TModule> where TModule :
		 IModule, new()
	{
		private readonly IContainer container;

		public IoCSupportedTest()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new TModule());

			container = builder.Build();
		}
		protected TEntity Resolve<TEntity>()
		{
			return container.Resolve<TEntity>();
		}
		protected void ShutDownIoc()
		{
			container.Dispose();
		}
	}
}

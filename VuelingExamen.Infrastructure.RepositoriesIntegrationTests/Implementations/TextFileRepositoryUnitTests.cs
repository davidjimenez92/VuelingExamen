using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExamen.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Test.Framework.Utils;
using VuelingExamen.Infrastructure.RepositoriesIntegrationTests.AutofacModules;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;

namespace VuelingExamen.Infrastructure.RepositoriesIntegrationTests.Implementations
{
    [TestClass()]
    public class TextFileRepositoryUnitTests: IoCSupportedTest<InfrastructureModuleTest>
    {
        private IFileRepository<Registry> _fileRepository;
        private Registry registry;

        [TestInitialize]
        public void Setup()
        {
            _fileRepository = Resolve<IFileRepository<Registry>>();
            registry = new Registry()
            {
                Rebeld = "David",
                Planet = "Tierra",
                RegisterDate = DateTime.Now
            };
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.IsTrue(_fileRepository.Add(registry));
        }
    }
}
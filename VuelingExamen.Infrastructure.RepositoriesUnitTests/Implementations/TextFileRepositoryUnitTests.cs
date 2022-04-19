using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExamen.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Domain.Entities;
using Autofac.Extras.Moq;
using VuelingExamen.Infrastructure.Repositories.Contracts;

namespace VuelingExamen.Infrastructure.RepositoriesUnitTests.Implementations
{
    [TestClass()]
    public class TextFileRepositoryUnitTests
    {
        private Registry registryToSave;

        [TestInitialize]
        public void Setup()
        {
            registryToSave = new Registry()
            {
                Rebeld = "David",
                Planet = "Tierra",
                RegisterDate = DateTime.Now
            };
        }

        [TestMethod()]
        public void AddTest()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFileRepository<Registry>>()
                    .Setup(repository => repository.Add(registryToSave))
                    .Returns(true);

                var mockedRepository = mock.Create<IFileRepository<Registry>>();

                var expectedResult = mockedRepository.Add(registryToSave); 

                mock.Mock<IFileRepository<Registry>>()
                    .Verify(repository => repository.Add(registryToSave));

                Assert.IsTrue(expectedResult);
            }
        }
    }
}
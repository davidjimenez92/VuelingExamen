using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExamen.Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Application.Dtos;
using Autofac.Extras.Moq;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.CrossCutting.ProjectConfiguration;

namespace VuelingExamen.Application.ServicesUnitTests.Implementations
{
    [TestClass()]
    public class VuelingRegisterServiceUnitTests
    {
        private RegistryDto _registryDto;

        [TestInitialize]
        public void Setup()
        {
            _registryDto = new RegistryDto()
            {
                Rebeled = "David",
                Planet = "Tierra",
            };
        }
        [TestMethod()]
        public void AddTest()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IVuelingService<RegistryDto>>()
                    .Setup(service => service.Add(_registryDto, FileType.Text))
                    .Returns(true);

                var mockedService = mock.Create<IVuelingService<RegistryDto>>();
                var spectedResult = mockedService.Add(_registryDto, FileType.Text);

                mock.Mock<IVuelingService<RegistryDto>>()
                    .Verify(service => service.Add(_registryDto, FileType.Text));

                Assert.IsNotNull(spectedResult);
            }
        }
    }
}
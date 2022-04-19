using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingExamen.Test.Framework.Utils;
using VuelingExamen.Application.ServicesIntegrationTests.AutofacModule;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.CrossCutting.ProjectConfiguration;

namespace VuelingExamen.Application.ServicesIntegrationTests.Implementations
{
    [TestClass()]
    public class VuelingRegisterServiceUnitTests: IoCSupportedTest<ServicesModuleTest>
    {
        private IVuelingService<RegistryDto> _service;
        private RegistryDto _registry;

        [TestInitialize]
        public void Setup()
        {
            _service = Resolve<IVuelingService<RegistryDto>>();
            _registry = new RegistryDto()
            {
                Rebeld = "David",
                Planet = "Tierra"
            };
        }
        [TestMethod()]
        public void AddTest()
        {
            Assert.IsTrue(_service.Add(_registry, FileType.Text));
        }
    }
}
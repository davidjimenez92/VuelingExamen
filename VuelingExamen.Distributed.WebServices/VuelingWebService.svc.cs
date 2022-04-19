using log4net;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Linq;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.CrossCutting.ProjectConfiguration;
using VuelingExamen.Distributed.WebServices.Contracts;

namespace VuelingExamen.Distributed.WebServices
{
    public class VuelingWebService : IVuelingWebService
    {
        private readonly ILog _logger;
        private readonly IVuelingService<RegistryDto> _vuelingService;

        public VuelingWebService(ILog logger, IVuelingService<RegistryDto> vuelingService)
        {
            _logger = logger;
            _vuelingService = vuelingService;
        }

        public bool Add([NotNullValidator(MessageTemplate = "List is null")] IEnumerable<string> data, FileType type = FileType.Text)
        {
            _logger.Debug(data.Count());
            var listData = data.ToList();
            var dto = new RegistryDto()
            {
                Rebeld = listData[0],
                Planet = listData[1]
            };

            _logger.Debug(dto);
            return _vuelingService.Add(dto, type);
        }
    }
}

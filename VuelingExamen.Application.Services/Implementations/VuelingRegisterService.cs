using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Application.Services.Contracts;
using VuelingExamen.CrossCutting.ProjectConfiguration;
using VuelingExamen.Domain.Entities;
using VuelingExamen.Infrastructure.Repositories.Contracts;

namespace VuelingExamen.Application.Services.Implementations
{
    public class VuelingRegisterService : IVuelingService<RegistryDto>
    {
        private readonly ILog _logger;
        private readonly IMapper _mapper;
        private readonly Func<FileType, IFileRepository<Registry>> _repoFactory;

        public VuelingRegisterService(ILog logger, IMapper mapper, Func<FileType, IFileRepository<Registry>> repoFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _repoFactory = repoFactory;
        }

        public bool Add(RegistryDto dto, FileType type)
        {
            _logger.Debug(dto);
            _logger.Debug(type);    
            if(dto == null)
                throw new ArgumentNullException(nameof(dto));

            dto.RegisterDate = DateTime.Now;

            var repository = _repoFactory(type);
            return repository.Add(_mapper.Map<Registry>(dto));
        }
    }
}

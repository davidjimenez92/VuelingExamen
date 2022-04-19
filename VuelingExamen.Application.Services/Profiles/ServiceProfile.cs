using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExamen.Application.Dtos;
using VuelingExamen.Domain.Entities;

namespace VuelingExamen.Application.Services.Profiles
{
    public class ServiceProfile: Profile
    {
        public ServiceProfile()
        {
            CreateMap<RegistryDto, Registry>();
        }
    }
}
